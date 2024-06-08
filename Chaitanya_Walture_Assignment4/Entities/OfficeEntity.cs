using Newtonsoft.Json;

namespace Chaitanya_Walture_Assignment4.Entities
{
    public class OfficeEntity:BaseClass
    {

        [JsonProperty(PropertyName = "Username", NullValueHandling = NullValueHandling.Ignore)]
        public String UserName { get; set; }
        [JsonProperty(PropertyName = "password", NullValueHandling = NullValueHandling.Ignore)]
        public String Password { get; set; }

        [JsonProperty(PropertyName = "location", NullValueHandling = NullValueHandling.Ignore)]
        public String Location { get; set; }
        [JsonProperty(PropertyName = "email", NullValueHandling = NullValueHandling.Ignore)]
        public String Email { get; set; }
        [JsonProperty(PropertyName = "phoneNumber", NullValueHandling = NullValueHandling.Ignore)]
        public String PhoneNumber { get; set; }
    }
}
