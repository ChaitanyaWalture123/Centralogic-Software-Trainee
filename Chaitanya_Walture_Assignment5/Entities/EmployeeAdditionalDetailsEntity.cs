using Newtonsoft.Json;
using System.Net;

namespace Chaitanya_Walture_Assignment5.Entities
{
    public class EmployeeAdditionalDetailsEntity:BaseEntity
    {
        [JsonProperty("employeeBasicDetailsUId")]
        public string EmployeeBasicDetailsUId { get; set; }

        [JsonProperty("alternateEmail")]
        public string AlternateEmail { get; set; }

        [JsonProperty("alternateMobile")]
        public string AlternateMobile { get; set; }

        [JsonProperty("workInformation")]
        public WorkInfo_ WorkInformation { get; set; }

        [JsonProperty("personalDetails")]
        public PersonalDetails_ PersonalDetails { get; set; }

        [JsonProperty("identityInformation")]
        public IdentityInfo_ IdentityInformation { get; set; }
    }
}
