using SacredBond.Common.Enums;

namespace SacredBond.Common.DTOs
{
    public class ProfileReligionDto : SimpleProfileDto
    {
        public string? ReligionImportance { get; set; }
        public bool? DoYouPray5Times { get; set; }
        public WearsHijabOptions? WearsHijab { get; set; }
        public bool? HasBeard { get; set; }
        public Genders Gender { get; set; }

    }
}
