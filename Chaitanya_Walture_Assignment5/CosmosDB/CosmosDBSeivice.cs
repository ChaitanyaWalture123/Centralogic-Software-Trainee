using Chaitanya_Walture_Assignment5.Entities;
using Chaitanya_Walture_Assignment5.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Azure.Cosmos;

namespace Chaitanya_Walture_Assignment5.CosmosDB
{
    public class CosmosDBSeivice : ICosmosDBService
    {

        private readonly string URI = "https://localhost:8081";
        private readonly string PrimaryKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
        private readonly string DatabaseName = "EmployeeManagementSystem";
        private readonly string ContainerName = "Employee";

        private Container container;

        public CosmosDBSeivice()
        {
            CosmosClient client = new CosmosClient(URI, PrimaryKey);
            Database database = client.GetDatabase(DatabaseName);
            container = database.GetContainer(ContainerName);
        }

        public async Task<EmployeeAdditionalDetailsEntity> AddEmployeeAdditionalDetails(EmployeeAdditionalDetailsEntity entity)
        {
            var response = await container.CreateItemAsync(entity);
            return response;
        }

        public async Task<List<EmployeeAdditionalDetailsEntity>> GetAllEmpolyeeAdditionalDetails()
        {
            var response = container.GetItemLinqQueryable<EmployeeAdditionalDetailsEntity>(true).Where(e => e.DocumentType == "EmployeeAdditionalDetails" && e.Active == true && e.Archived == false).ToList();
            return response;
        }

        public async Task<EmployeeAdditionalDetailsEntity> GetAllEmpolyeeAdditionalDetailsById(string id)
        {
            var response = container.GetItemLinqQueryable<EmployeeAdditionalDetailsEntity>(true).Where(e => e.DocumentType == "EmployeeAdditionalDetails" && e.EmployeeBasicDetailsUId == id && e.Active == true && e.Archived == false).FirstOrDefault();
            return response;
        }

        public async Task UpdateEmpolyeeAdditionalDetails(EmployeeAdditionalDetailsEntity existingEmployee, string uId)
        {
            await container.ReplaceItemAsync(existingEmployee, uId);
        }

        public async Task UpdateEmpolyeeBasicDetails(EmployeeBasicDetailsEntity existingEmployee, string uId)
        {
            await container.ReplaceItemAsync(existingEmployee, uId);
        }

        async Task<EmployeeBasicDetailsEntity> ICosmosDBService.AddEmpolyeeBasicDetails(EmployeeBasicDetailsEntity entity)
        {
            var response = await container.CreateItemAsync(entity);
            return response;
        }

        async Task<List<EmployeeBasicDetailsEntity>> ICosmosDBService.GetAllEmpolyeeBasicDetails()
        {
            var response = container.GetItemLinqQueryable<EmployeeBasicDetailsEntity>(true).Where(e => e.DocumentType == "EmployeeBasicDetails" && e.Active == true && e.Archived == false).ToList();
            return response;
        }

        async Task<EmployeeBasicDetailsEntity> ICosmosDBService.GetEmpolyeeBasicDetailsByEmpId(string employeeID)
        {
            var response = container.GetItemLinqQueryable<EmployeeBasicDetailsEntity>(true).Where(e => e.DocumentType == "EmployeeBasicDetails" && e.EmployeeID == employeeID && e.Active == true && e.Archived == false).FirstOrDefault();
            return response;
        }

        

   
    }
}
