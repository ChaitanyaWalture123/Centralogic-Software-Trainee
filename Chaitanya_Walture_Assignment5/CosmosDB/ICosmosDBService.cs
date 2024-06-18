using Chaitanya_Walture_Assignment5.Entities;
using Chaitanya_Walture_Assignment5.Model;

namespace Chaitanya_Walture_Assignment5.CosmosDB
{
    public interface ICosmosDBService
    {
        Task<EmployeeAdditionalDetailsEntity> AddEmployeeAdditionalDetails(EmployeeAdditionalDetailsEntity entity);
        Task<EmployeeBasicDetailsEntity> AddEmpolyeeBasicDetails(EmployeeBasicDetailsEntity entity);
        Task<List<EmployeeAdditionalDetailsEntity>> GetAllEmpolyeeAdditionalDetails();
        Task<EmployeeAdditionalDetailsEntity> GetAllEmpolyeeAdditionalDetailsById(string id);
        Task<List<EmployeeBasicDetailsEntity>> GetAllEmpolyeeBasicDetails();
        Task<EmployeeBasicDetailsEntity> GetEmpolyeeBasicDetailsByEmpId(string employeeID);
        Task UpdateEmpolyeeAdditionalDetails(EmployeeAdditionalDetailsEntity existingEmployee, string uId);
        Task UpdateEmpolyeeBasicDetails(EmployeeBasicDetailsEntity existingEmployee, string uId);
    }
}
