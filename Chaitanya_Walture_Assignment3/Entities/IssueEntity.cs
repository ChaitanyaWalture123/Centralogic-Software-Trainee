using Newtonsoft.Json;

namespace Chaitanya_Walture_Assignment3.Entities
{
    public class IssueEntity : BaseClass
    {


        [JsonProperty(PropertyName = "bookid", NullValueHandling = NullValueHandling.Ignore)]
        public string BookId { get; set; }

        [JsonProperty(PropertyName = "memberid", NullValueHandling = NullValueHandling.Ignore)]
        public string MemberId { get; set; }

        [JsonProperty(PropertyName = "issuedate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime IssueDate { get; set; }

        [JsonProperty(PropertyName = "returndate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime ReturnDate { get; set; }

        [JsonProperty(PropertyName = "isreturned", NullValueHandling = NullValueHandling.Ignore)]
        public bool isReturned { get; set; }
    }
}
