using Chaitanya_Walture_Assignment5.CosmosDB;
using Chaitanya_Walture_Assignment5.Entities;
using Chaitanya_Walture_Assignment5.Interface;
using Chaitanya_Walture_Assignment5.Model;

namespace Chaitanya_Walture_Assignment5.Service
{
    public class EmployeeAdditionalDetailsService : IEmployeeAdditionalDetailsService
    {
        public readonly ICosmosDBService _cosmosDBService;
        public EmployeeAdditionalDetailsService(ICosmosDBService cosmosDBService)
        {

            _cosmosDBService = cosmosDBService;


        }
        public async Task<EmployeeAdditionalDetailsModel> AddEmpolyeeAdditionalDetails(EmployeeAdditionalDetailsModel employee)
        {

          
        EmployeeAdditionalDetailsEntity entity = new EmployeeAdditionalDetailsEntity();
            entity.EmployeeBasicDetailsUId= employee.EmployeeBasicDetailsUId;
            entity.AlternateEmail= employee.AlternateEmail;
            entity.AlternateMobile= employee.AlternateMobile;
            entity.WorkInformation = employee.WorkInformation;
            entity.PersonalDetails = employee.PersonalDetails;
            entity.IdentityInformation= employee.IdentityInformation;

            entity.Id = Guid.NewGuid().ToString();
            entity.UId = entity.Id;
            entity.DocumentType = "EmployeeAdditionalDetails";
            entity.CreatedBy = "Employee";
            entity.CreatedOn = DateTime.Now;
            entity.UpdatedBy = "";
            entity.UpdatedOn = DateTime.Now;
            entity.Version = 1;
            entity.Active = true;
            entity.Archived = false;


            var response = await _cosmosDBService.AddEmployeeAdditionalDetails(entity);

            EmployeeAdditionalDetailsModel employeeModel = new EmployeeAdditionalDetailsModel();
            employeeModel.EmployeeBasicDetailsUId = response.EmployeeBasicDetailsUId;
            employeeModel.AlternateEmail = response.AlternateEmail;
            employeeModel.AlternateMobile = response.AlternateMobile;
            employeeModel.WorkInformation = response.WorkInformation;
            employeeModel.PersonalDetails = response.PersonalDetails;
            employeeModel.IdentityInformation = response.IdentityInformation;
            return employeeModel;


        }

        public async Task DeleteEmpolyeeAdditionalDetails(string id)
        {
            var employee = await _cosmosDBService.GetAllEmpolyeeAdditionalDetailsById(id);
            if (employee != null)
            {
                employee.Active = false;
                employee.Archived = true;
                await _cosmosDBService.UpdateEmpolyeeAdditionalDetails(employee, employee.UId);
            }
            else
            {
                throw new Exception("Employee not found");
            }
        }

        public async Task<List<EmployeeAdditionalDetailsModel>> GetAllEmpolyeeAdditionalDetails()
        {
            var response = await _cosmosDBService.GetAllEmpolyeeAdditionalDetails();
            var employees = new List<EmployeeAdditionalDetailsModel>();

            foreach (var employee in response)
            {
                EmployeeAdditionalDetailsModel employeeModel = new EmployeeAdditionalDetailsModel();


                employeeModel.EmployeeBasicDetailsUId = employee.EmployeeBasicDetailsUId;
                employeeModel.AlternateEmail = employee.AlternateEmail;
                employeeModel.AlternateMobile = employee.AlternateMobile;
                employeeModel.WorkInformation = employee.WorkInformation;
                employeeModel.PersonalDetails = employee.PersonalDetails;
                employeeModel.IdentityInformation = employee.IdentityInformation;


                employees.Add(employeeModel);
            }

            return employees;
        }

        public async Task<EmployeeAdditionalDetailsModel> GetAllEmpolyeeAdditionalDetailsById(string id)
        {

            var employee = await _cosmosDBService.GetAllEmpolyeeAdditionalDetailsById(id);

                EmployeeAdditionalDetailsModel employeeModel = new EmployeeAdditionalDetailsModel();

                employeeModel.EmployeeBasicDetailsUId = employee.EmployeeBasicDetailsUId;
                employeeModel.AlternateEmail = employee.AlternateEmail;
                employeeModel.AlternateMobile = employee.AlternateMobile;
                employeeModel.WorkInformation = employee.WorkInformation;
                employeeModel.PersonalDetails = employee.PersonalDetails;
                employeeModel.IdentityInformation = employee.IdentityInformation;

            return employeeModel;


            }

        public async Task<EmployeeAdditionalDetailsModel> UpdateEmpolyeeAdditionalDetails(EmployeeAdditionalDetailsModel employee)
        {

            var existingEmployee = await _cosmosDBService.GetAllEmpolyeeAdditionalDetailsById(employee.EmployeeBasicDetailsUId);
            if (existingEmployee != null)
            {
                existingEmployee.Active = false;
                existingEmployee.Archived = true;
                await _cosmosDBService.UpdateEmpolyeeAdditionalDetails(existingEmployee, existingEmployee.UId);
                EmployeeAdditionalDetailsEntity newEmployee = new EmployeeAdditionalDetailsEntity();

                newEmployee.EmployeeBasicDetailsUId = employee.EmployeeBasicDetailsUId;
                newEmployee.AlternateEmail = employee.AlternateEmail;
                newEmployee.AlternateMobile = employee.AlternateMobile;
                newEmployee.WorkInformation = employee.WorkInformation;
                newEmployee.PersonalDetails = employee.PersonalDetails;
                newEmployee.IdentityInformation = employee.IdentityInformation;

                newEmployee.Id = Guid.NewGuid().ToString();
                newEmployee.UId = existingEmployee.UId;
                newEmployee.DocumentType = "EmployeeAdditionalDetails";
                newEmployee.CreatedBy = "Employee";
                newEmployee.CreatedOn = DateTime.Now;
                newEmployee.UpdatedBy = "Chaitanya";
                newEmployee.UpdatedOn = DateTime.Now;
                newEmployee.Version = existingEmployee.Version + 1;
                newEmployee.Active = true;
                newEmployee.Archived = false;

                var response = await _cosmosDBService.AddEmployeeAdditionalDetails(newEmployee);

                EmployeeAdditionalDetailsModel employeeModel = new EmployeeAdditionalDetailsModel();

                employeeModel.EmployeeBasicDetailsUId = response.EmployeeBasicDetailsUId;
                employeeModel.AlternateEmail = response.AlternateEmail;
                employeeModel.AlternateMobile = response.AlternateMobile;
                employeeModel.WorkInformation = response.WorkInformation;
                employeeModel.PersonalDetails = response.PersonalDetails;
                employeeModel.IdentityInformation = response.IdentityInformation;
                return employeeModel;
            }
            else
            {

                throw new Exception("Employee not found");
            }
        }
    }

}
