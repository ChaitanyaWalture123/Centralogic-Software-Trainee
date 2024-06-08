using Chaitanya_Walture_Assignment4.DTO;

namespace Chaitanya_Walture_Assignment4.Interfaces
{
    public interface IVisitorService
    {
        Task<RequestDTO> ApproveRequsest(string Id);
        Task<List<VisitorDTO>> GetAllRequest();
        Task<List<RequestDTO>> GetApprovedRequest();
        Task<RequestDTO> GetVisitorByVisitorId(string visitorId);
        Task<List<RequestDTO>> PendingRequest();
        Task<VisitorDTO> RegisterVisitor(VisitorDTO visitor);
        Task<List<RequestDTO>> RejectedRequest();
        Task<RequestDTO> RejectRequest(string id);
    }
}
