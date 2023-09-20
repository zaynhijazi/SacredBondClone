using SacredBond.Common.Enums;

namespace SacredBond.Common.DTOs
{
    public class ProfileAboutDto : SimpleProfileDto
    {
        public AllSomeNot? ActiveEnergetic { get; set; }
        public AllSomeNot? Adaptable { get; set; }
        public AllSomeNot? Sensitive { get; set; }
        public AllSomeNot? Flexible { get; set; }
        public AllSomeNot? LaidBack { get; set; }
        public AllSomeNot? Patient { get; set; }
        public AllSomeNot? Practical { get; set; }
        public AllSomeNot? Private { get; set; }
        public AllSomeNot? Shy { get; set; }
        public AllSomeNot? Social { get; set; }
        public string? ShareAboutYourself { get; set; }
        public string? DescribeTypicalDay { get; set; }
        public string? ShortTermGoals { get; set; }
        public string? LongTermGoals { get; set; }
        public string? HobbiesAndActivities { get; set; }
    }
}
