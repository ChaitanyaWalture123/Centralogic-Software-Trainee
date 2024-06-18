using Chaitanya_Walture_Assignment5.Model;

namespace Chaitanya_Walture_Assignment5.Interface
{
    public interface IEmployeeBasicDetailsService
    { 
        Task<EmployeeBasicDetailsModel> AddEmpolyeeBasicDetails(EmployeeBasicDetailsModel employeeBasicDetailsModel);
        Task DeleteEmpolyeeBasicDetails(string id);
        Task<List<EmployeeBasicDetailsModel>> GetAllEmpolyeeBasicDetails();
        Task<EmployeeBasicDetailsModel> GetEmpolyeeBasicDetailsByEmpId(string id);
        Task<EmployeeBasicDetailsModel> UpdateEmpolyeeBasicDetails(EmployeeBasicDetailsModel employee);
    }
}
