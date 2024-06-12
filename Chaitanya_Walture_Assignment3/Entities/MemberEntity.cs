using Newtonsoft.Json;

namespace Chaitanya_Walture_Assignment3.Entities
{
    public class MemberEntity : BaseClass
    {


        [JsonProperty(PropertyName = "Name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "dateofbirth", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime DateOfBirth { get; set; }

        [JsonProperty(PropertyName = "email", NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }

    }
}
