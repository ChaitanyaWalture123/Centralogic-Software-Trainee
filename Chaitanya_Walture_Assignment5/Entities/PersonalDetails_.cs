using Newtonsoft.Json;

namespace Chaitanya_Walture_Assignment5.Entities
{
    public class PersonalDetails_
    {
        [JsonProperty("dateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [JsonProperty("age")]
        public string Age { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("religion")]
        public string Religion { get; set; }

        [JsonProperty("caste")]
        public string Caste { get; set; }

        [JsonProperty("maritalStatus")]
        public string MaritalStatus { get; set; }

        [JsonProperty("bloodGroup")]
        public string BloodGroup { get; set; }

        [JsonProperty("height")]
        public string Height { get; set; }

        [JsonProperty("weight")]
        public string Weight { get; set; }

    }
}
