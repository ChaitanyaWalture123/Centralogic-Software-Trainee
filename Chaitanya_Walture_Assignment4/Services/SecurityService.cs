using Chaitanya_Walture_Assignment4.CosmosDB;
using Chaitanya_Walture_Assignment4.DTO;
using Chaitanya_Walture_Assignment4.Entities;
using Chaitanya_Walture_Assignment4.Interfaces;

namespace Chaitanya_Walture_Assignment4.Services
{
    public class SecurityService : ISecurityService
    {


        public readonly ICosmosDBService _icsmosDBService;
        public SecurityService(ICosmosDBService cosmosDBService)
        {
            _icsmosDBService = cosmosDBService;
        }

        public async Task<SecurityDTO> LoginSecurityUser(string username, string password)
        {
            var response = await _icsmosDBService.LoginSecurityUser(username, password);
            var responseModel = new SecurityDTO();
            if (response == null)
            {
                return null;
            }
            responseModel.Username = response.Username;
            responseModel.Password = response.Password;
            return responseModel;
        }

        public async Task<SecurityDTO> RegisterSecurity(SecurityDTO securityDTO)
        {
            SecurityEntity securityEntity = new SecurityEntity();
            securityEntity.Username = securityDTO.Username;
            securityEntity.Password = securityDTO.Password;
            securityEntity.Email = securityDTO.Email;
            securityEntity.PhoneNumber = securityDTO.PhoneNumber;
            securityEntity.Name = securityDTO.Name;

            securityEntity.Id = Guid.NewGuid().ToString();
            securityEntity.UId = securityEntity.Id;
            securityEntity.DocumentType = "Security";
            securityEntity.CreatedOn = DateTime.Now;
            securityEntity.CreatedByName = "chaitanya";
            securityEntity.UpdatedOn = DateTime.Now;
            securityEntity.UpdatedBy = "Chaitanya";
            securityEntity.Version = 1;
            securityEntity.Active = true;
            securityEntity.Archieved = false;

            var response = await _icsmosDBService.RegisterSecurity(securityEntity);

            var responseModel = new SecurityDTO();
            responseModel.Username = securityDTO.Username;
            responseModel.Password = securityDTO.Password;
            responseModel.Email = securityDTO.Email;
            responseModel.PhoneNumber = securityDTO.PhoneNumber;
            responseModel.Name = securityDTO.Name;

            return responseModel;

        }
    }
}
