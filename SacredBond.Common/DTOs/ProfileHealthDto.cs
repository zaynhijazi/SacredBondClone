namespace SacredBond.Common.DTOs
{
    public class ProfileHealthDto : SimpleProfileDto
    {
        public bool? HaveHealthIssues { get; set; }
        public string? HealthIssues { get; set; }
        public string? PhysicalImpediments { get; set; }
    }
}
