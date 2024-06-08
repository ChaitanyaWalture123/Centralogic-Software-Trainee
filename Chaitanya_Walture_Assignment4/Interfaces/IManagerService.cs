using Chaitanya_Walture_Assignment4.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Chaitanya_Walture_Assignment4.Interfaces
{
    public interface IManagerService
    {
        Task<ManagerDTO> LoginManager(string username, string password);
        Task<ManagerDTO> RegisterManager(ManagerDTO managerModel);
        
    }
}
