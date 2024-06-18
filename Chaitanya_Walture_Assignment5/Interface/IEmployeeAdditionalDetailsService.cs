using Chaitanya_Walture_Assignment5.Entities;
using Chaitanya_Walture_Assignment5.Model;

namespace Chaitanya_Walture_Assignment5.Interface
{
    public interface IEmployeeAdditionalDetailsService
    {
        Task<EmployeeAdditionalDetailsModel> AddEmpolyeeAdditionalDetails(EmployeeAdditionalDetailsModel employee);
        Task DeleteEmpolyeeAdditionalDetails(string id);
        Task<List<EmployeeAdditionalDetailsModel>> GetAllEmpolyeeAdditionalDetails();
        Task<EmployeeAdditionalDetailsModel> GetAllEmpolyeeAdditionalDetailsById(string id);
        Task<EmployeeAdditionalDetailsModel> UpdateEmpolyeeAdditionalDetails(EmployeeAdditionalDetailsModel employee);
    }


}
