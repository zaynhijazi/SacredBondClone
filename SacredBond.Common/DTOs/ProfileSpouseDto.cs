using SacredBond.Common.Enums;

namespace SacredBond.Common.DTOs
{
    public class ProfileSpouseDto : SimpleProfileDto
    {
        public AllSomeNot? WantSpouseActiveEnergetic { get; set; }
        public AllSomeNot? WantSpouseAdaptable { get; set; }
        public AllSomeNot? WantSpouseSensitive { get; set; }
        public AllSomeNot? WantSpouseFlexible { get; set; }
        public AllSomeNot? WantSpouseLaidBack { get; set; }
        public AllSomeNot? WantSpousePatient { get; set; }
        public AllSomeNot? WantSpousePractical { get; set; }
        public AllSomeNot? WantSpousePrivate { get; set; }
        public AllSomeNot? WantSpouseShy { get; set; }
        public AllSomeNot? WantSpouseSocial { get; set; }

        public int? MinimumSpouseAge { get; set; }
        public int? MaximumSpouseAge { get; set; }

        public SpouseMaritalStatuses? SpouseMaritalStatuses { get; set; }
        public YesNoMaybeOptions? ConsiderSpouseWithChildren { get; set; }
        public string? LookingForInSpouse { get; set; }
        public WaliOptions? DoYouHaveAWali { get; set; }
        public string? WaliName { get; set; }
        public string? WaliRelationship { get; set; }
        public string? WaliPhone { get; set; }
        public string? WaliEmail { get; set; }
        public Genders Gender { get; set; }

    }
}
