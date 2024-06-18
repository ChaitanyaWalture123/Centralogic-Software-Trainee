using Newtonsoft.Json;

namespace Chaitanya_Walture_Assignment5.Entities
{
    public class Address
    {
        [JsonProperty(PropertyName = "streetAddress", NullValueHandling = NullValueHandling.Ignore)]
        public string StreetAddress { get; set; }

        [JsonProperty(PropertyName = "city", NullValueHandling = NullValueHandling.Ignore)]
        public string City { get; set; }

        [JsonProperty(PropertyName = "state", NullValueHandling = NullValueHandling.Ignore)]
        public string State { get; set; }

        [JsonProperty(PropertyName = "zipCode", NullValueHandling = NullValueHandling.Ignore)]
        public string ZipCode { get; set; }


    }
}
