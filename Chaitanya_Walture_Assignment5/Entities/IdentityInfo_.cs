using Newtonsoft.Json;

namespace Chaitanya_Walture_Assignment5.Entities
{
    public class IdentityInfo_
    {
        [JsonProperty("pan")]
        public string PAN { get; set; }

        [JsonProperty("aadhar")]
        public string Aadhar { get; set; }

        [JsonProperty("nationality")]
        public string Nationality { get; set; }

        [JsonProperty("passportNumber")]
        public string PassportNumber { get; set; }

        [JsonProperty("pfNumber")]
        public string PFNumber { get; set; }
    }
}
