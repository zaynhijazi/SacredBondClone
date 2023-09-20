using Microsoft.Extensions.Hosting;
using SacredBond.Common.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace SacredBond.Core.Domain;
public class ProfileStatusChange
{
    public int Id { get; set; }
    [ForeignKey("ProfileId")] 
    public int ProfileId { get; set; }
    public ProfileStatus FromStatus { get; set; }
    public ProfileStatus ToStatus { get; set; }
    public DateTime CreateTime { get; set; }
    public string CreatedBy { get; set; } = string.Empty;

}