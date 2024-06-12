using Newtonsoft.Json;

namespace Chaitanya_Walture_Assignment3.Entities
{
    public class BaseClass
    {
        [JsonProperty(PropertyName = "uid", NullValueHandling = NullValueHandling.Ignore)]
        public string UId { get; set; }

        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "dtype", NullValueHandling = NullValueHandling.Ignore)]
        public string DocumentType { get; set; }

        [JsonProperty(PropertyName = "version", NullValueHandling = NullValueHandling.Ignore)]
        public int Version { get; set; }

        [JsonProperty(PropertyName = "createdby", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedBy { get; set; }

        [JsonProperty(PropertyName = "createdon", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime Createdon { get; set; }

        [JsonProperty(PropertyName = "updatedby", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedBy { get; set; }

        [JsonProperty(PropertyName = "updatedon", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime UpdatedOn { get; set; }

        [JsonProperty(PropertyName = "active", NullValueHandling = NullValueHandling.Ignore)]
        public bool Active { get; set; }

        [JsonProperty(PropertyName = "archived", NullValueHandling = NullValueHandling.Ignore)]
        public bool Archived { get; set; }
    }
}
