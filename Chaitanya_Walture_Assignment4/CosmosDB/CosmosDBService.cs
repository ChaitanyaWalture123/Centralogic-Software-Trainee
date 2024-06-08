using Chaitanya_Walture_Assignment4.Common;
using Chaitanya_Walture_Assignment4.DTO;
using Chaitanya_Walture_Assignment4.Entities;
using Microsoft.Azure.Cosmos;

namespace Chaitanya_Walture_Assignment4.CosmosDB
{
    public class CosmosDBService : ICosmosDBService
    {
        public CosmosClient _cosmosClient;
        private readonly Container _container;
        public CosmosDBService()
        {
            _cosmosClient = new CosmosClient(Credentials.URI, Credentials.PrimaryKey);
            _container = _cosmosClient.GetContainer(Credentials.DatabaseName, Credentials.ContainerName);
        }

        public async Task<VisitorEntity> RegisterVisitor(VisitorEntity entity)
        {
            var response = await _container.CreateItemAsync(entity);

            return response;

        }

        public async Task<ManagerEntity> RegisterManager(ManagerEntity managerEntity)
        {
            var response = await _container.CreateItemAsync(managerEntity);

            return response;

        }

        public async Task<OfficeEntity> RegisterOffice(OfficeEntity officeEntity)
        {
            var response = await _container.CreateItemAsync(officeEntity);

            return response;
        }

        public async Task<SecurityEntity> RegisterSecurity(SecurityEntity securityEntity)
        {
            var response = await _container.CreateItemAsync(securityEntity);

            return response;

        }

        public async Task<List<VisitorEntity>> GetAllVisitors()
        {
            var response = _container.GetItemLinqQueryable<VisitorEntity>(true).Where(q => q.DocumentType == "Visitor" && q.Archieved == false && q.Active == true).ToList();
            return response;
        }

        public async Task<List<VisitorEntity>> GetApprovedRequest()
        {
            var response = _container.GetItemLinqQueryable<VisitorEntity>(true).Where(q => q.DocumentType == "Visitor" && q.Archieved == false && q.Status == "Approved" && q.Active == true).ToList();
            return response;
        }

        public async Task<List<VisitorEntity>> RejectedRequest()
        {
            var response = _container.GetItemLinqQueryable<VisitorEntity>(true).Where(q => q.DocumentType == "Visitor" && q.Archieved == false && q.Status == "Rejected" && q.Active == true).ToList();
            return response;

        }

        public async Task<List<VisitorEntity>> PendingRequest()
        {
            var response = _container.GetItemLinqQueryable<VisitorEntity>(true).Where(q => q.DocumentType == "Visitor" && q.Archieved == false && q.Status == "Pending" && q.Active == true).ToList();
            return response;

        }

        public async Task<ManagerEntity> LoginManager(string username, string password)
        {
            var manager = _container.GetItemLinqQueryable<ManagerEntity>(true).Where(q => q.DocumentType == "Manager" && q.Active == true && q.Archieved == false && q.Username == username && q.Password == password).FirstOrDefault();
            return manager;
        }

        public async Task<VisitorEntity> GetVisitorByVisitorId(string visitorId)
        {
            var visitor = _container.GetItemLinqQueryable<VisitorEntity>(true).Where(q => q.DocumentType == "Visitor" && q.Id == visitorId && q.Archieved == false && q.Active == true).FirstOrDefault();
            return visitor;
        }

        public async Task<OfficeEntity> LoginOfficeUser(string username, string password)
        {
            var office = _container.GetItemLinqQueryable<OfficeEntity>(true).Where(q => q.DocumentType == "Office" && q.Active == true && q.Archieved == false && q.UserName == username && q.Password == password).FirstOrDefault();
            return office;
        }

        public async Task<VisitorEntity> ReplaceRecord(VisitorEntity existingRecord, string id)
        {
            var response = await _container.ReplaceItemAsync(existingRecord, id);
            return response;
        }

        public async Task<SecurityEntity> LoginSecurityUser(string username, string password)
        {
            var security = _container.GetItemLinqQueryable<SecurityEntity>(true).Where(q => q.DocumentType == "Security" && q.Active == true && q.Archieved == false && q.Username == username && q.Password == password).FirstOrDefault();
            return security;

        }
    }
}
