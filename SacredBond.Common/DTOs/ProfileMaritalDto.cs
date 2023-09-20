using SacredBond.Common.Enums;

namespace SacredBond.Common.DTOs
{
    public class ProfileMaritalDto : SimpleProfileDto
    {
        public MaritalStatuses? MaritalStatus { get; set; }
        public bool? HasChildren { get; set; }
        public int? NumberOfChildren { get; set; }
    }
}
