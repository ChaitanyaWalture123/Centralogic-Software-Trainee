using Chaitanya_Walture_Assignment5.Entities;
using Chaitanya_Walture_Assignment5.Interface;
using Chaitanya_Walture_Assignment5.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos.Serialization.HybridRow.Schemas;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;


namespace Chaitanya_Walture_Assignment5.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class EmployeeManagementSytemController : Controller {

        public readonly IEmployeeBasicDetailsService _employeeBasicDetails;
        public readonly IEmployeeAdditionalDetailsService _employeeAdditionalDetails;

        public EmployeeManagementSytemController(IEmployeeBasicDetailsService employeeBasicDetails, IEmployeeAdditionalDetailsService employeeAdditionalDetails)
        {
            _employeeBasicDetails = employeeBasicDetails;
            _employeeAdditionalDetails = employeeAdditionalDetails;
        }

        [HttpPost("AddEmpolyeeBasicDetails")]
        public async Task<EmployeeBasicDetailsModel> AddEmpolyeeBasicDetails(EmployeeBasicDetailsModel employeeBasicDetailsModel)
        {
            var response = await _employeeBasicDetails.AddEmpolyeeBasicDetails(employeeBasicDetailsModel);
            return response;
        }

        [HttpGet("GetAllEmpolyeeBasicDetails")]
        public async Task<List<EmployeeBasicDetailsModel>> GetAllEmpolyeeBasicDetails()
        {
            var response = await _employeeBasicDetails.GetAllEmpolyeeBasicDetails();
            return response;
        }

        [HttpGet("GetEmpolyeeBasicDetailsById")]
        public async Task<EmployeeBasicDetailsModel> GetEmpolyeeBasicDetailsById(string Id)
        {
            var response = await _employeeBasicDetails.GetEmpolyeeBasicDetailsByEmpId(Id);
            return response;
        }

        [HttpPut("UpdateEmpolyeeBasicDetails")]
        public async Task<EmployeeBasicDetailsModel> UpdateEmpolyeeBasicDetails(EmployeeBasicDetailsModel employee)
        {
            var response = await _employeeBasicDetails.UpdateEmpolyeeBasicDetails(employee);
            return response;
        }

        [HttpDelete("DeleteEmpolyeeBasicDetails")]
        public async Task<IActionResult> DeleteEmpolyeeBasicDetails(string id)
        {
            await _employeeBasicDetails.DeleteEmpolyeeBasicDetails(id);
            return Ok("Record Deleted Successfully");
        }

        private string GetStringFromCell(ExcelWorksheet worksheet, int row , int column)
        {
            var cellvalue= worksheet.Cells[row, column].Value;
            return cellvalue?.ToString()?.Trim();
        }

        [HttpPost("ImportEmpolyeeBasicDetails")]
        public async Task<IActionResult> ImportEmpolyeeBasicDetails(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("File is Empty or null");

            var employees = new List<EmployeeBasicDetailsModel>();
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            
            using(var stream = new  MemoryStream())
            {
                file.CopyTo(stream);
                using (var package = new ExcelPackage(stream))
                {
                    var worksheet = package.Workbook.Worksheets[0];
                    var rowCount = worksheet.Dimension.Rows;
                    for (int row = 2; row < rowCount; row++)
                    {
                        var employee = new EmployeeBasicDetailsModel
                        {
                            Salutory = GetStringFromCell(worksheet, row, 1),

                            FirstName = GetStringFromCell(worksheet, row, 2),
                            MiddleName = GetStringFromCell(worksheet, row, 3),
                            LastName = GetStringFromCell(worksheet, row, 4),
                            NickName = GetStringFromCell(worksheet, row, 5),
                            Email = GetStringFromCell(worksheet, row, 6),
                            Mobile = GetStringFromCell(worksheet, row, 7),
                            EmployeeID = GetStringFromCell(worksheet, row, 8),
                            Role = GetStringFromCell(worksheet, row, 9),
                            ReportingManagerUId = GetStringFromCell(worksheet, row, 10),
                            ReportingManagerName = GetStringFromCell(worksheet, row, 11),
                            Address = new Address
                            {
                                StreetAddress = GetStringFromCell(worksheet, row, 12),
                                City = GetStringFromCell(worksheet, row, 13),
                                State = GetStringFromCell(worksheet, row, 14),
                                ZipCode = GetStringFromCell(worksheet, row, 15)
                            }
                    };

                        await AddEmpolyeeBasicDetails(employee);
                        employees.Add(employee);    
                    
                    }
                }

                    }
            return Ok((employees));
                }


        [HttpGet("ExportEmpolyeeBasicDetails")]
        public async Task<IActionResult> ExportEmpolyeeBasicDetails()

        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var employees = await _employeeBasicDetails.GetAllEmpolyeeBasicDetails();

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Employees");

                
                worksheet.Cells[1, 1].Value = "Salutory";
                worksheet.Cells[1, 2].Value = "FirstName";
                worksheet.Cells[1, 3].Value = "MiddleName";
                worksheet.Cells[1, 4].Value = "LastName";
                worksheet.Cells[1, 5].Value = "NickName";
                worksheet.Cells[1, 6].Value = "Email";
                worksheet.Cells[1, 7].Value = "Mobile";
                worksheet.Cells[1, 8].Value = "EmployeeID";
                worksheet.Cells[1, 9].Value = "Role";
                worksheet.Cells[1, 10].Value = "ReportingManagerUId";
                worksheet.Cells[1, 11].Value = "ReportingManagerName";
                worksheet.Cells[1, 12].Value = "StreetAddress";
                worksheet.Cells[1, 13].Value = "City";
                worksheet.Cells[1, 14].Value = "State";
                worksheet.Cells[1, 15].Value = "ZipCode";

                
                using (var range = worksheet.Cells[1, 1, 1, 15])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.LightGreen);
                }

                
                for (int i = 0; i < employees.Count; i++)
                {
                    var employee = employees[i];
                    worksheet.Cells[i + 2, 1].Value = employee.Salutory;
                    worksheet.Cells[i + 2, 2].Value = employee.FirstName;
                    worksheet.Cells[i + 2, 3].Value = employee.MiddleName;
                    worksheet.Cells[i + 2, 4].Value = employee.LastName;
                    worksheet.Cells[i + 2, 5].Value = employee.NickName;
                    worksheet.Cells[i + 2, 6].Value = employee.Email;
                    worksheet.Cells[i + 2, 7].Value = employee.Mobile;
                    worksheet.Cells[i + 2, 8].Value = employee.EmployeeID;
                    worksheet.Cells[i + 2, 9].Value = employee.Role;
                    worksheet.Cells[i + 2, 10].Value = employee.ReportingManagerUId;
                    worksheet.Cells[i + 2, 11].Value = employee.ReportingManagerName;
                    worksheet.Cells[i + 2, 12].Value = employee.Address.StreetAddress;
                    worksheet.Cells[i + 2, 13].Value = employee.Address.City;
                    worksheet.Cells[i + 2, 14].Value = employee.Address.State;
                    worksheet.Cells[i + 2, 15].Value = employee.Address.ZipCode;
                }

                var stream = new MemoryStream();
                package.SaveAs(stream);
                stream.Position = 0;

                var fileName = "Employees.xlsx";
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
            }
        }



        [HttpPost("AddEmpolyeeAdditionalDetails")]
        public async Task<EmployeeAdditionalDetailsModel> AddEmpolyeeAdditionalDetails(EmployeeAdditionalDetailsModel employee)
        {
            var response = await _employeeAdditionalDetails.AddEmpolyeeAdditionalDetails(employee);
            return response;
        }

        [HttpGet("GetAllEmpolyeeAdditionalDetails")]
        public async Task<List<EmployeeAdditionalDetailsModel>> GetAllEmpolyeeAdditionalDetails()
        {
            var response = await _employeeAdditionalDetails.GetAllEmpolyeeAdditionalDetails();
            return response;
        }

        [HttpGet("GetAllEmpolyeeAdditionalDetailsById")]
        public async Task<EmployeeAdditionalDetailsModel> GetAllEmpolyeeAdditionalDetailsById(string id)
        {
            var response = await _employeeAdditionalDetails.GetAllEmpolyeeAdditionalDetailsById(id);
            return response;
        }


        [HttpPut("UpdateEmpolyeeAdditionalDetails")]
        public async Task<EmployeeAdditionalDetailsModel> UpdateEmpolyeeAdditionalDetails(EmployeeAdditionalDetailsModel employee)
        {
            var response = await _employeeAdditionalDetails.UpdateEmpolyeeAdditionalDetails(employee);
            return response;
        }


        [HttpDelete("DeleteEmpolyeeAdditionalDetailsById")]
        public async Task<IActionResult> DeleteEmpolyeeAdditionalDetails(string id)
        {
            await _employeeAdditionalDetails.DeleteEmpolyeeAdditionalDetails(id);
            return Ok("Record Deleted Successfully");
        }


        

        private DateTime? GetDateTimeFromCell(ExcelWorksheet worksheet, int row, int column)
        {
            if (DateTime.TryParse(worksheet.Cells[row, column].Value?.ToString(), out DateTime dateValue))
            {
                return dateValue;
            }
            return null;
        }

        [HttpPost("ImportEmployeeAdditionalDetails")]
        public async Task<IActionResult> ImportEmployeeAdditionalDetails(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("File is empty or null");

            var employees = new List<EmployeeAdditionalDetailsModel>();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var stream = new MemoryStream())
            {
                file.CopyTo(stream);
                using (var package = new ExcelPackage(stream))
                {
                    var worksheet = package.Workbook.Worksheets[0];
                    var rowCount = worksheet.Dimension.Rows;

                    for (int row = 2; row < rowCount; row++)
                    {
                       

                        var employee = new EmployeeAdditionalDetailsModel
                        {
                            EmployeeBasicDetailsUId = GetStringFromCell(worksheet, row, 1),
                            AlternateEmail = GetStringFromCell(worksheet, row, 2),
                            AlternateMobile = GetStringFromCell(worksheet, row, 3),
                            WorkInformation = new WorkInfo_
                            {
                                DesignationName = GetStringFromCell(worksheet, row, 4),
                                DepartmentName = GetStringFromCell(worksheet, row, 5),
                                LocationName = GetStringFromCell(worksheet, row, 6),
                                EmployeeStatus = GetStringFromCell(worksheet, row, 7),
                                SourceOfHire = GetStringFromCell(worksheet, row, 8),
                                DateOfJoining = GetDateTimeFromCell(worksheet, row, 9) ?? DateTime.MinValue
                            },
                            PersonalDetails = new PersonalDetails_
                            {
                                DateOfBirth = GetDateTimeFromCell(worksheet, row, 10) ?? DateTime.MinValue,
                                Age = GetStringFromCell(worksheet, row, 11),
                                Gender = GetStringFromCell(worksheet, row, 12),
                                Religion = GetStringFromCell(worksheet, row, 13),
                                Caste = GetStringFromCell(worksheet, row, 14),
                                MaritalStatus = GetStringFromCell(worksheet, row, 15),
                                BloodGroup = GetStringFromCell(worksheet, row, 16),
                                Height = GetStringFromCell(worksheet, row, 17),
                                Weight = GetStringFromCell(worksheet, row, 18)
                            },
                            IdentityInformation = new IdentityInfo_
                            {
                                PAN = GetStringFromCell(worksheet, row, 19),
                                Aadhar = GetStringFromCell(worksheet, row, 20),
                                Nationality = GetStringFromCell(worksheet, row, 21),
                                PassportNumber = GetStringFromCell(worksheet, row, 22),
                                PFNumber = GetStringFromCell(worksheet, row, 23)
                            }
                        };

                        await _employeeAdditionalDetails.AddEmpolyeeAdditionalDetails(employee);
                        employees.Add(employee);
                    }
                }
            }

            return Ok(employees);
        }

        [HttpGet("ExportEmployeeAdditionalDetails")]
        public async Task<IActionResult> ExportEmployeeAdditionalDetails()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var employees = await _employeeAdditionalDetails.GetAllEmpolyeeAdditionalDetails();

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("EmployeeAdditionalDetails");

                
                worksheet.Cells[1, 1].Value = "EmployeeBasicDetailsUId";
                worksheet.Cells[1, 2].Value = "AlternateEmail";
                worksheet.Cells[1, 3].Value = "AlternateMobile";
                worksheet.Cells[1, 4].Value = "DesignationName";
                worksheet.Cells[1, 5].Value = "DepartmentName";
                worksheet.Cells[1, 6].Value = "LocationName";
                worksheet.Cells[1, 7].Value = "EmployeeStatus";
                worksheet.Cells[1, 8].Value = "SourceOfHire";
                worksheet.Cells[1, 9].Value = "DateOfJoining";
                worksheet.Cells[1, 10].Value = "DateOfBirth";
                worksheet.Cells[1, 11].Value = "Age";
                worksheet.Cells[1, 12].Value = "Gender";
                worksheet.Cells[1, 13].Value = "Religion";
                worksheet.Cells[1, 14].Value = "Caste";
                worksheet.Cells[1, 15].Value = "MaritalStatus";
                worksheet.Cells[1, 16].Value = "BloodGroup";
                worksheet.Cells[1, 17].Value = "Height";
                worksheet.Cells[1, 18].Value = "Weight";
                worksheet.Cells[1, 19].Value = "PAN";
                worksheet.Cells[1, 20].Value = "Aadhar";
                worksheet.Cells[1, 21].Value = "Nationality";
                worksheet.Cells[1, 22].Value = "PassportNumber";
                worksheet.Cells[1, 23].Value = "PFNumber";

                
                using (var range = worksheet.Cells[1, 1, 1, 23])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.LightGreen);
                }

                
                for (int i = 0; i < employees.Count; i++)
                {
                    var employee = employees[i];
                    worksheet.Cells[i + 2, 1].Value = employee.EmployeeBasicDetailsUId;
                    worksheet.Cells[i + 2, 2].Value = employee.AlternateEmail;
                    worksheet.Cells[i + 2, 3].Value = employee.AlternateMobile;
                    worksheet.Cells[i + 2, 4].Value = employee.WorkInformation.DesignationName;
                    worksheet.Cells[i + 2, 5].Value = employee.WorkInformation.DepartmentName;
                    worksheet.Cells[i + 2, 6].Value = employee.WorkInformation.LocationName;
                    worksheet.Cells[i + 2, 7].Value = employee.WorkInformation.EmployeeStatus;
                    worksheet.Cells[i + 2, 8].Value = employee.WorkInformation.SourceOfHire;
                    worksheet.Cells[i + 2, 9].Value = employee.WorkInformation.DateOfJoining.ToString("yyyy-MM-dd");
                    worksheet.Cells[i + 2, 10].Value = employee.PersonalDetails.DateOfBirth.ToString("yyyy-MM-dd");
                    worksheet.Cells[i + 2, 11].Value = employee.PersonalDetails.Age;
                    worksheet.Cells[i + 2, 12].Value = employee.PersonalDetails.Gender;
                    worksheet.Cells[i + 2, 13].Value = employee.PersonalDetails.Religion;
                    worksheet.Cells[i + 2, 14].Value = employee.PersonalDetails.Caste;
                    worksheet.Cells[i + 2, 15].Value = employee.PersonalDetails.MaritalStatus;
                    worksheet.Cells[i + 2, 16].Value = employee.PersonalDetails.BloodGroup;
                    worksheet.Cells[i + 2, 17].Value = employee.PersonalDetails.Height;
                    worksheet.Cells[i + 2, 18].Value = employee.PersonalDetails.Weight;
                    worksheet.Cells[i + 2, 19].Value = employee.IdentityInformation.PAN;
                    worksheet.Cells[i + 2, 20].Value = employee.IdentityInformation.Aadhar;
                    worksheet.Cells[i + 2, 21].Value = employee.IdentityInformation.Nationality;
                    worksheet.Cells[i + 2, 22].Value = employee.IdentityInformation.PassportNumber;
                    worksheet.Cells[i + 2, 23].Value = employee.IdentityInformation.PFNumber;
                }

                var stream = new MemoryStream();
                package.SaveAs(stream);
                stream.Position = 0;

                var fileName = "EmployeeAdditionalDetails.xlsx";
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
            }
        }



    }
}
