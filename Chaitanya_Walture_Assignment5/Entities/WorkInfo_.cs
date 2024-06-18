using Newtonsoft.Json;

namespace Chaitanya_Walture_Assignment5.Entities
{
    public class WorkInfo_
    {

        [JsonProperty("designationName")]
        public string DesignationName { get; set; }

        [JsonProperty("departmentName")]
        public string DepartmentName { get; set; }

        [JsonProperty("locationName")]
        public string LocationName { get; set; }

        [JsonProperty("employeeStatus")]
        public string EmployeeStatus { get; set; } // Terminated, Active, Resigned etc

        [JsonProperty("sourceOfHire")]
        public string SourceOfHire { get; set; }

        [JsonProperty("dateOfJoining")]
        public DateTime DateOfJoining { get; set; }
    }
}
