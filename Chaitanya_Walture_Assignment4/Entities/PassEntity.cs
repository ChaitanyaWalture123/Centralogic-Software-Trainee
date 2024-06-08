using Newtonsoft.Json;

namespace Chaitanya_Walture_Assignment4.Entities
{
    public class PassEntity
    {

        [JsonProperty(PropertyName = "visitorName", NullValueHandling = NullValueHandling.Ignore)]
        private String VisitorName { get; set; }
        [JsonProperty(PropertyName = "visitorEmail", NullValueHandling = NullValueHandling.Ignore)]
        private String VisitorEmail { get; set; }

        [JsonProperty(PropertyName = "visitingTo", NullValueHandling = NullValueHandling.Ignore)]
        private String VisitingTo { get; set; }
        [JsonProperty(PropertyName = "purpose", NullValueHandling = NullValueHandling.Ignore)]
        private String Purpose { get; set; }
        [JsonProperty(PropertyName = "entryTime", NullValueHandling = NullValueHandling.Ignore)]
        private DateTime EntryTime { get; set; }
        [JsonProperty(PropertyName = "exitTime", NullValueHandling = NullValueHandling.Ignore)]
        private DateTime ExitTime { get; set; }
        [JsonProperty(PropertyName = "passStatus", NullValueHandling = NullValueHandling.Ignore)]
        private String passStatus { get; set; }

    }
}
