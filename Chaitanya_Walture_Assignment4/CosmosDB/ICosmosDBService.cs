using Chaitanya_Walture_Assignment4.DTO;
using Chaitanya_Walture_Assignment4.Entities;

namespace Chaitanya_Walture_Assignment4.CosmosDB
{
    public interface ICosmosDBService
    {
        
        Task<VisitorEntity> ReplaceRecord(VisitorEntity existingRecord, string id);
        Task<List<VisitorEntity>> GetAllVisitors();
        Task<List<VisitorEntity>> GetApprovedRequest();
        Task<VisitorEntity> GetVisitorByVisitorId(string visitorId);
        Task<ManagerEntity> LoginManager(string username, string password);
        Task<OfficeEntity> LoginOfficeUser(string username, string password);
        Task<List<VisitorEntity>> PendingRequest();
        Task<ManagerEntity> RegisterManager(ManagerEntity managerEntity);

        Task<OfficeEntity> RegisterOffice(OfficeEntity officeEntity);
        Task<SecurityEntity> RegisterSecurity(SecurityEntity securityEntity);
        Task<VisitorEntity> RegisterVisitor(VisitorEntity entity);
        Task<List<VisitorEntity>> RejectedRequest();
        Task <SecurityEntity>LoginSecurityUser(string username, string password);
    }
}
