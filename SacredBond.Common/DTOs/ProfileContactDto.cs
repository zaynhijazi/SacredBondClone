using SacredBond.Common.Enums;

namespace SacredBond.Common.DTOs
{
    public class ProfileContactDto : SimpleProfileDto
    {
        public ContactMethods? BestWayToContact { get; set; }
        public bool? ShareInfoWithMatches { get; set; }
        public YesNoMaybeOptions? HasDomesticViolenceHistory { get; set; }
    }
}
