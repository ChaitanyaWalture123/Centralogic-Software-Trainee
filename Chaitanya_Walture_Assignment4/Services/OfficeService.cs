using Chaitanya_Walture_Assignment4.CosmosDB;
using Chaitanya_Walture_Assignment4.DTO;
using Chaitanya_Walture_Assignment4.Entities;
using Chaitanya_Walture_Assignment4.Interfaces;

namespace Chaitanya_Walture_Assignment4.Services
{
    public class OfficeService :IOfficeService
    {
        public readonly ICosmosDBService _icsmosDBService;
        public OfficeService(ICosmosDBService cosmosDBService)
        {
            _icsmosDBService = cosmosDBService;
        }

        public async Task<OfficeDTO> LoginOfficeUser(string username, string password)
        {
            var response = await _icsmosDBService.LoginOfficeUser(username, password);
            var responseModel = new OfficeDTO();
            if (response == null)
            {
                return null;
            }
            responseModel.UserName = response.UserName;
            responseModel.Password = response.Password;
            return responseModel;
        }

       

        public async Task<OfficeDTO> RegisterOffice(OfficeDTO officeModel)
        {
            OfficeEntity officeEntity = new OfficeEntity();
            officeEntity.UserName = officeModel.UserName;
            officeEntity.Password = officeModel.Password;
            officeEntity.Email = officeModel.Email;
            officeEntity.PhoneNumber = officeModel.PhoneNumber;
            officeEntity.Location = officeModel.Location;


            officeEntity.Id = Guid.NewGuid().ToString();
            officeEntity.UId = officeEntity.Id;
            officeEntity.DocumentType = "Office";
            officeEntity.CreatedOn = DateTime.Now;
            officeEntity.CreatedByName = "chaitanya";
            officeEntity.UpdatedOn = DateTime.Now;
            officeEntity.UpdatedBy = "Chaitanya";
            officeEntity.Version = 1;
            officeEntity.Active = true;
            officeEntity.Archieved = false;

            var response = await _icsmosDBService.RegisterOffice(officeEntity);

            var responseModel = new OfficeDTO();

            responseModel.Email = officeModel.Email;
            responseModel.Password= officeModel.Password;
            responseModel.PhoneNumber = officeModel.PhoneNumber;
            responseModel.UserName = officeModel.UserName;
            responseModel.Location = officeModel.Location;
            return responseModel;

        }

    }
}
