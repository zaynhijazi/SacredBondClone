using SacredBond.Common.Enums;

namespace SacredBond.Common.DTOs
{
    public class SimpleProfileDto
    {
        public int ProfileId { get; set; }
        public ProfileStatus Status { get; set; }
        public DateTime StatusChangedDate { get; set; }
        public DateTime? SubmittedDate { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public DateTime? RejectedDate { get; set; }
        public string RejectReason { get; set; }
        public bool CanEditProfile { get; set; }

        public bool IsPersonalCompleted { get; set; }
        public bool IsPicturesCompleted { get; set; }
        public bool IsEducationalProfessionalCompleted { get; set; }
        public bool IsMaritalCompleted { get; set; }
        public bool IsReligionCompleted { get; set; }
        public bool IsAboutCompleted { get; set; }
        public bool IsSpouseCompleted { get; set; }
        public bool IsHealthCompleted { get; set; }
        public bool IsFamilyCompleted { get; set; }
        public bool IsFinanceCompleted { get; set; }
        public bool IsContactCompleted { get; set; }
    }
}
