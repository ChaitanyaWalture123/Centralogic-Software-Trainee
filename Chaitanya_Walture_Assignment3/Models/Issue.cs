using Newtonsoft.Json;

namespace Chaitanya_Walture_Assignment3.Models
{
    public class Issue
    {
       
        public string UId { get; set; }

        public string BookId { get; set; }

        public string MemberId { get; set; }

        public DateTime IssueDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public bool isReturned { get; set; }

        public string BookTitle { get; set; }
    }

}
