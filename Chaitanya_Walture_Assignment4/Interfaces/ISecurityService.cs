using Chaitanya_Walture_Assignment4.DTO;

namespace Chaitanya_Walture_Assignment4.Interfaces
{
    public interface ISecurityService
    {
        Task<SecurityDTO> LoginSecurityUser(string username, string password);
        Task<SecurityDTO> RegisterSecurity(SecurityDTO securityDTO);
    }
}
