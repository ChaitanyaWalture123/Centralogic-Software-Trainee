using Chaitanya_Walture_Assignment4.Entities;
using Newtonsoft.Json;

namespace Chaitanya_Walture_Assignment4.DTO
{
    public class VisitorDTO

    {
        public String Name { get; set; }
        public String Email { get; set; }
        public String PhoneNumber { get; set; }
        public String Address { get; set; }
        public String VisitingTo { get; set; }
        public String Purpose { get; set; }
        public DateTime EntryTime { get; set; }
        public DateTime ExitTime { get; set; }

  
    }

    public class RequestDTO : VisitorDTO
    {
        public string Status { get; set; }
    }
}
