using Newtonsoft.Json;

namespace Chaitanya_Walture_Assignment3.Entities
{
    public class BookEntity : BaseClass
    {
        

        [JsonProperty(PropertyName = "title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "author", NullValueHandling = NullValueHandling.Ignore)]
        public string Author { get; set; }

        [JsonProperty(PropertyName = "publishdate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime PublishedDate { get; set; }

        [JsonProperty(PropertyName = "isbn", NullValueHandling = NullValueHandling.Ignore)]
        public string ISBN { get; set; }

        [JsonProperty(PropertyName = "isissued", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsIssued { get; set; }
    }
}
