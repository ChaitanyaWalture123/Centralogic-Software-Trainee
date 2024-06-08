using Chaitanya_Walture_Assignment4.CosmosDB;
using Chaitanya_Walture_Assignment4.DTO;
using Chaitanya_Walture_Assignment4.Entities;
using Chaitanya_Walture_Assignment4.Interfaces;

namespace Chaitanya_Walture_Assignment4.Services
{
    public class ManagerService :IManagerService
    {
        public readonly ICosmosDBService _icsmosDBService;
        public ManagerService(ICosmosDBService cosmosDBService)
        {
            _icsmosDBService = cosmosDBService;
        }

        public async Task<ManagerDTO> LoginManager(string username, string password)
        {
            var response = await _icsmosDBService.LoginManager(username, password);
            var responseModel = new ManagerDTO();
            if (response == null)
            {
                return null;
            }
            responseModel.UserName = response.Username;
            responseModel.Password = response.Password;
            return responseModel;
        }

        public async Task<ManagerDTO> RegisterManager(ManagerDTO managerModel)
        {
            ManagerEntity managerEntity= new ManagerEntity();

            managerEntity.Username = managerModel.UserName;
            managerEntity.Password = managerModel.Password;
            managerModel.Name = managerModel.Name;
            managerModel.Email = managerModel.Email;
            managerModel.PhoneNumber = managerModel.PhoneNumber;

            managerEntity.Id = Guid.NewGuid().ToString();
            managerEntity.UId = managerEntity.Id;
            managerEntity.DocumentType = "Manager";
            managerEntity.CreatedOn = DateTime.Now;
            managerEntity.CreatedByName = "chaitanya";
            managerEntity.UpdatedOn = DateTime.Now;
            managerEntity.UpdatedBy = "Chaitanya";
            managerEntity.Version = 1;
            managerEntity.Active = true;
            managerEntity.Archieved = false;

            var response = await _icsmosDBService.RegisterManager(managerEntity);

            var responseModel = new ManagerDTO();
            responseModel.UserName = managerModel.UserName;
            responseModel.Password = managerModel.Password;
            responseModel.Email = managerModel.Email;
            responseModel.PhoneNumber = managerModel.PhoneNumber;
            responseModel.Name = managerModel.Name;
            return responseModel;
        }

      
    }
}
