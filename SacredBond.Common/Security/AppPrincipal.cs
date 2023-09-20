using SacredBond.Common.Enums;
using System.Security.Claims;
using System.Security.Principal;

namespace SacredBond.Common.Security
{
    public interface IAppPrincipal : IPrincipal
    {
        Guid Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Name { get; }
        string Email { get; set; }
        string Phone { get; set; }
        string Role { get; set; }
        bool IsAdmin { get; set; }
        int ProfileId { get; set; }
        Genders Gender { get; set; }
    }

    public class AppPrincipal : IAppPrincipal
    {
        public IIdentity Identity { get; private set; }
        public bool IsInRole(string role) { return this.Role == role; }

        public AppPrincipal(string email)
        {
            this.Identity = new GenericIdentity(email);
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get { return $"{FirstName} {LastName}"; } }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
        public bool IsAdmin { get; set; }
        public int ProfileId { get; set; }
        public Genders Gender { get; set; }
    }
}
