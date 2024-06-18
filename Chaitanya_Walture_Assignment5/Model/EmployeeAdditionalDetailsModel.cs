using Chaitanya_Walture_Assignment5.Entities;


namespace Chaitanya_Walture_Assignment5.Model
{
    public class EmployeeAdditionalDetailsModel
    {
        public string EmployeeBasicDetailsUId { get; set; }
        public string AlternateEmail { get; set; }
        public string AlternateMobile { get; set; }
        public WorkInfo_ WorkInformation { get; set; }
        public PersonalDetails_ PersonalDetails { get; set; }
        public IdentityInfo_ IdentityInformation { get; set; }
    }
}
