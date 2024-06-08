using Newtonsoft.Json;

namespace Chaitanya_Walture_Assignment4.Entities
{
    public class SecurityEntity : BaseClass
    {
        [JsonProperty(PropertyName = "userName", NullValueHandling = NullValueHandling.Ignore)]
        public String Username { get; set; }
        [JsonProperty(PropertyName = "password", NullValueHandling = NullValueHandling.Ignore)]
        public String Password { get; set; }
        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
        public String Name { get; set; }
        [JsonProperty(PropertyName = "email", NullValueHandling = NullValueHandling.Ignore)]
        public String Email { get; set; }
        [JsonProperty(PropertyName = "phoneNumber", NullValueHandling = NullValueHandling.Ignore)]
        public String PhoneNumber { get; set; }
    }
}
