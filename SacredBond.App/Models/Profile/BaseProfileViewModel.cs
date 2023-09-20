namespace SacredBond.App.Models.Profile
{
    public class BaseProfileViewModel
    {
        public int ProfileId { get; set; }
        public bool IsPending { get; set; }
        public bool IsSubmitted { get; set; }
        public bool IsApproved { get; set; }
        public bool IsRejected { get; set; }
        public string? RejectReason { get; set; }
        public bool HasBeenApproved { get; set; }
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
        public bool CanEditProfile { get; set; }
    }
}
