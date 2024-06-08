using Newtonsoft.Json;

namespace Chaitanya_Walture_Assignment4.Entities
{
    public class VisitorEntity : BaseClass
    {
        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
        public String Name { get; set; }
        [JsonProperty(PropertyName = "email", NullValueHandling = NullValueHandling.Ignore)]
        public String Email { get; set; }
        [JsonProperty(PropertyName = "phoneNumber", NullValueHandling = NullValueHandling.Ignore)]
        public String PhoneNumber { get; set; }
        [JsonProperty(PropertyName = "address", NullValueHandling = NullValueHandling.Ignore)]
        public String Address { get; set; }
        [JsonProperty(PropertyName = "visitingTo", NullValueHandling = NullValueHandling.Ignore)]
        public String VisitingTo { get; set; }
        [JsonProperty(PropertyName = "purpose", NullValueHandling = NullValueHandling.Ignore)]
        public String Purpose { get; set; }
        [JsonProperty(PropertyName = "entryTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime EntryTime { get; set; }
        [JsonProperty(PropertyName = "exitTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime ExitTime { get; set; }

        [JsonProperty(PropertyName = "status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }


    }
 
}
