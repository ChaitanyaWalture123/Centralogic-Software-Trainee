using Chaitanya_Walture_Assignment5.CosmosDB;
using Chaitanya_Walture_Assignment5.Entities;
using Chaitanya_Walture_Assignment5.Interface;
using Chaitanya_Walture_Assignment5.Model;
using System.ComponentModel;
using System.IO.Compression;
using System.Reflection.Metadata.Ecma335;

namespace Chaitanya_Walture_Assignment5.Service
{
    public class EmployeeBasicDetailsService : IEmployeeBasicDetailsService
    {
        public readonly ICosmosDBService _cosmosDBService;
        public EmployeeBasicDetailsService(ICosmosDBService cosmosDBService) {

            _cosmosDBService = cosmosDBService;


        }
        public async Task<EmployeeBasicDetailsModel> AddEmpolyeeBasicDetails(EmployeeBasicDetailsModel employeeBasicDetailsModel)
        {
            EmployeeBasicDetailsEntity entity = new EmployeeBasicDetailsEntity();
            entity.Salutory = employeeBasicDetailsModel.Salutory;
            entity.FirstName = employeeBasicDetailsModel.FirstName;
            entity.MiddleName = employeeBasicDetailsModel.MiddleName;
            entity.LastName = employeeBasicDetailsModel.LastName;
            entity.NickName = employeeBasicDetailsModel.NickName;
            entity.Email = employeeBasicDetailsModel.Email;
            entity.Mobile = employeeBasicDetailsModel.Mobile;
            entity.EmployeeID = employeeBasicDetailsModel.EmployeeID;
            entity.Role= employeeBasicDetailsModel.Role;
            entity.ReportingManagerUId = employeeBasicDetailsModel.ReportingManagerUId;
            entity.ReportingManagerName= employeeBasicDetailsModel.ReportingManagerName;
            entity.Address = employeeBasicDetailsModel.Address;


            // mandetory fields

            
            entity.Id= Guid.NewGuid().ToString();
            entity.UId = entity.Id;
            entity.DocumentType = "EmployeeBasicDetails";
            entity.CreatedBy = "Employee";
            entity.CreatedOn= DateTime.Now;
            entity.UpdatedBy = "";
            entity.UpdatedOn= DateTime.Now;
            entity.Version= 1;
            entity.Active = true;
            entity.Archived = false;

           var response = await _cosmosDBService.AddEmpolyeeBasicDetails(entity);

            EmployeeBasicDetailsModel employeeModel = new EmployeeBasicDetailsModel();
            employeeModel.Salutory=response.Salutory;
            employeeModel.FirstName= response.FirstName;
            employeeModel.MiddleName= response.MiddleName;
            employeeModel.LastName= response.LastName;
            employeeModel.NickName = response.NickName;
            employeeModel.Email= response.Email;
            employeeModel.Mobile= response.Mobile;
            employeeModel.EmployeeID= response.EmployeeID;
            employeeModel.Role= response.Role;
            employeeModel.ReportingManagerUId= response.ReportingManagerUId;
            employeeModel.ReportingManagerName= response.ReportingManagerName;
            employeeModel.Address= response.Address;

            return employeeModel;

        }

        public async Task DeleteEmpolyeeBasicDetails(string id)
        {
            var employee = await _cosmosDBService.GetEmpolyeeBasicDetailsByEmpId(id);
            if (employee != null)
            {
                employee.Active = false;
                employee.Archived = true;
                await _cosmosDBService.UpdateEmpolyeeBasicDetails(employee, employee.UId);
            }
            else
            {
                throw new Exception("Employee not found");
            }
        }


        public async Task<List<EmployeeBasicDetailsModel>> GetAllEmpolyeeBasicDetails()
        {
            var response = await _cosmosDBService.GetAllEmpolyeeBasicDetails();
            var employees =new List<EmployeeBasicDetailsModel>();

            foreach(var employee in response) {

                EmployeeBasicDetailsModel employeeModel = new EmployeeBasicDetailsModel();
                employeeModel.Salutory = employee.Salutory;
                employeeModel.FirstName = employee.FirstName;
                employeeModel.MiddleName = employee.MiddleName;
                employeeModel.LastName = employee.LastName;
                employeeModel.NickName = employee.NickName;
                employeeModel.Email = employee.Email;
                employeeModel.Mobile = employee.Mobile;
                employeeModel.EmployeeID = employee.EmployeeID;
                employeeModel.Role = employee.Role;
                employeeModel.ReportingManagerUId = employee.ReportingManagerUId;
                employeeModel.ReportingManagerName = employee.ReportingManagerName;
                employeeModel.Address = employee.Address;
                employees.Add(employeeModel);

           }
        return employees;
        }

        public async Task<EmployeeBasicDetailsModel> GetEmpolyeeBasicDetailsByEmpId(string Id)
        {
            var employee = await _cosmosDBService.GetEmpolyeeBasicDetailsByEmpId(Id);


            EmployeeBasicDetailsModel employeeModel = new EmployeeBasicDetailsModel();
            employeeModel.Salutory = employee.Salutory;
            employeeModel.FirstName = employee.FirstName;
            employeeModel.MiddleName = employee.MiddleName;
            employeeModel.LastName = employee.LastName;
            employeeModel.NickName = employee.NickName;
            employeeModel.Email = employee.Email;
            employeeModel.Mobile = employee.Mobile;
            employeeModel.EmployeeID = employee.EmployeeID;
            employeeModel.Role = employee.Role;
            employeeModel.ReportingManagerUId = employee.ReportingManagerUId;
            employeeModel.ReportingManagerName = employee.ReportingManagerName;
            employeeModel.Address = employee.Address;

            return employeeModel;
        }

        public async Task<EmployeeBasicDetailsModel> UpdateEmpolyeeBasicDetails(EmployeeBasicDetailsModel employee)
        {
            var existingEmployee = await _cosmosDBService.GetEmpolyeeBasicDetailsByEmpId(employee.EmployeeID);
            if (existingEmployee != null)
            {
                existingEmployee.Active = false;
                existingEmployee.Archived = true;
                await _cosmosDBService.UpdateEmpolyeeBasicDetails(existingEmployee, existingEmployee.UId);
                EmployeeBasicDetailsEntity newEmployee = new EmployeeBasicDetailsEntity();
                newEmployee.Id = Guid.NewGuid().ToString();
                newEmployee.UId = existingEmployee.UId;
                newEmployee.DocumentType = "EmployeeBasicDetails";
                newEmployee.CreatedBy = "Employee";
                newEmployee.CreatedOn = DateTime.Now;
                newEmployee.UpdatedBy = "Chaitanya";
                newEmployee.UpdatedOn = DateTime.Now;
                newEmployee.Version = existingEmployee.Version + 1;
                newEmployee.Active = true;
                newEmployee.Archived = false;

                newEmployee.Salutory = employee.Salutory;
                newEmployee.FirstName = employee.FirstName;
                newEmployee.MiddleName = employee.MiddleName;
                newEmployee.LastName = employee.LastName;
                newEmployee.NickName = employee.NickName;
                newEmployee.Email = employee.Email;
                newEmployee.Mobile = employee.Mobile;
                newEmployee.EmployeeID = employee.EmployeeID;
                newEmployee.Role = employee.Role;
                newEmployee.ReportingManagerUId = employee.ReportingManagerUId;
                newEmployee.ReportingManagerName = employee.ReportingManagerName;
                newEmployee.Address = employee.Address;

                var response = await _cosmosDBService.AddEmpolyeeBasicDetails(newEmployee);

                EmployeeBasicDetailsModel employeeModel = new EmployeeBasicDetailsModel();
                employeeModel.Salutory = response.Salutory;
                employeeModel.FirstName = response.FirstName;
                employeeModel.MiddleName = response.MiddleName;
                employeeModel.LastName = response.LastName;
                employeeModel.NickName = response.NickName;
                employeeModel.Email = response.Email;
                employeeModel.Mobile = response.Mobile;
                employeeModel.EmployeeID = response.EmployeeID;
                employeeModel.Role = response.Role;
                employeeModel.ReportingManagerUId = response.ReportingManagerUId;
                employeeModel.ReportingManagerName = response.ReportingManagerName;
                employeeModel.Address = response.Address;

                return employeeModel;
            }
            else
            {
                
                throw new Exception("Employee not found");
            }
        }


    }
}
