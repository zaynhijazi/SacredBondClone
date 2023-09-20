using SacredBond.Common.DTOs;
using SacredBond.Common.Enums;
using System.Security.Claims;

namespace SacredBond.Common.Security
{
    public class ClaimsTransformation
    {
        public static AppPrincipal? Transform(ClaimsPrincipal principle)
        {
            if (principle == null)
                return null;

            var userName = GetClaim(principle, ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userName))
                return null;

            AppPrincipal newUser = new (userName);
            newUser.Id = GetClaimGuid(principle, ClaimTypes.Sid);
            newUser.FirstName = GetClaim(principle, ClaimTypes.GivenName);
            newUser.LastName = GetClaim(principle, ClaimTypes.Surname);
            newUser.Email = GetClaim(principle, ClaimTypes.Email);
            newUser.Phone = GetClaim(principle, ClaimTypes.MobilePhone);
            newUser.Role = GetClaim(principle, ClaimTypes.Role);
            newUser.ProfileId = GetClaimInt(principle, ClaimTypes.Spn);
            newUser.Gender = (Genders)GetClaimInt(principle, ClaimTypes.Gender);
            return newUser;
        }

        public static Claim[] GetCalims(AppPrincipal user)
        {
            return new[]
            {
                new Claim(ClaimTypes.Sid, user.Id.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Email),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName),
                new Claim(ClaimTypes.MobilePhone, user.Phone),
                new Claim(ClaimTypes.Role, user.IsAdmin ? Roles.Admin : Roles.Regular),
                new Claim(ClaimTypes.Spn, user.ProfileId.ToString()),
                new Claim(ClaimTypes.Gender, ((int)user.Gender).ToString())
            };
        }

        private static string GetClaim(ClaimsPrincipal principal, string type)
        {
            return principal.Claims.FirstOrDefault(o => o.Type == type)?.Value;
        }

        private static Guid GetClaimGuid(ClaimsPrincipal principal, string type)
        {
            var claim = GetClaim(principal, type);
            if (string.IsNullOrEmpty(claim))
                return Guid.Empty;
            return new Guid(claim);
        }

        private static int GetClaimInt(ClaimsPrincipal principal, string type)
        {
            var claim = GetClaim(principal, type);
            if (string.IsNullOrEmpty(claim))
                return 0;
            return Convert.ToInt32(claim);
        }
    }
}
