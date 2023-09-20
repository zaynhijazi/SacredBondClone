using SacredBond.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace SacredBond.App.Models.Profile
{
    public class PersonalViewModel : BaseProfileViewModel
    {
        [Display(Name = "Full Name")]
        public string? FullName { get; set; }

        [Display(Name = "Gender")]
        public Genders? Gender { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string? Phone { get; set; }
        

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "Address Line 1")]
        [Required] 
        public string? AddressLine1 { get; set; }
        
        [Display(Name = "Address Line 2")]
        public string? AddressLine2 { get; set; }
        
        [Display(Name = "City")]
        [Required] 
        public string? City { get; set; }
         
        [Display(Name = "State")]
        [Required] 
        public States? State { get; set; }
        
        [Display(Name = "Zip Code")]
        [DataType(DataType.PostalCode)]
        [Required] 
        public string? ZipCode { get; set; }

        [Display(Name = "Legal Status In Country of Residence")]
        [Required] 
        public LegalStatuses? LegalStatus { get; set; }

        [Display(Name = "What's your Ethnicity?")]
        [Required] 
        public Ethnicities? Ethnicity { get; set; }

        [Display(Name = "Primary Language(s) Spoken At Home")]
        [Required] 
        public List<LanguagesEnum> PrimaryLanguages { get; set; } = new List<LanguagesEnum>();

        [Display(Name = "Do you have a preference of which language you prefer to speak with to a Sacred Bond representative?")]
        [Required] 
        public LanguagesEnum? PreferredLanguage { get; set; }

        public ProfileStatus Status { get; set; }

        [Display(Name = "Created Time")]
        public DateTime CreateTime { get; set; }

        [Display(Name = "Submitted Date")]
        public DateTime? SubmittedDate { get; set; }

        [Display(Name = "Rejected Date")] 
        public DateTime? RejectedDate { get; set; }

        [Display(Name = "Approved Date")]
        public DateTime? ApprovedDate { get; set; }

        [Display(Name = "Status Changed Date")]
        public DateTime StatusChangedDate { get; set; }

    }
}
