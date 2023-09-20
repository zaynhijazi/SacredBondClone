using SacredBond.Common.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace SacredBond.Core.Domain;
public class ProfileMatchStatusChange
{
    public int Id { get; set; }
    [ForeignKey("MatchId")]
    public int MatchId { get; set; }
    public InterestedInStatus FromStatus { get; set; }
    public InterestedInStatus ToStatus { get; set; }
    public DateTime CreateTime { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
}   