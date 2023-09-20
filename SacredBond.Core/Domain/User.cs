using Microsoft.AspNetCore.Identity;
using SacredBond.Common.Enums;

namespace SacredBond.Core.Domain
{
    public class User : IdentityUser<Guid>
    {
        public int ProfileId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? StripeCustomerId { get; set; }
        public string? SubscriptionId { get; set; }
        public Genders Gender { get; set; }

        public virtual Profile Profile { get; set; } = new Profile();
    }
}
