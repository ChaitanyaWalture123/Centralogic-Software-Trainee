using Chaitanya_Walture_Assignment5.Entities;

namespace Chaitanya_Walture_Assignment5.Model
{
    public class EmployeeBasicDetailsModel
    {
        
        public string Salutory { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string EmployeeID { get; set; }
        public string Role { get; set; }
        public string ReportingManagerUId { get; set; }
        public string ReportingManagerName { get; set; }
        public Address Address { get; set; }
    }
}
