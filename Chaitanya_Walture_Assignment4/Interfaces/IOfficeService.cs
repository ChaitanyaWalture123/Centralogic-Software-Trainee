using Chaitanya_Walture_Assignment4.DTO;

namespace Chaitanya_Walture_Assignment4.Interfaces
{
    public interface IOfficeService
    {
        Task<OfficeDTO> LoginOfficeUser(string username, string password);
      
        Task<OfficeDTO> RegisterOffice(OfficeDTO officeModel);
       
    }
}
