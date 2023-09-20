using Microsoft.Extensions.Logging;
using SacredBond.Common.Security;
using System.Security.Claims;
using System.Security.Principal;

namespace SacredBond.Core.Services
{
    public abstract class BaseService
    {
        public ILogger Logger { get; set; }
        public IPrincipal Principle { get; set; }
        
        public BaseService(ILogger logger, IPrincipal principal)
        {
            Logger = logger;
            Principle = principal;
        }

        private AppPrincipal _user;
        protected AppPrincipal User
        {
            get
            {
                if (_user != null)
                    return _user;

                var principle = Principle as ClaimsPrincipal;
                if (principle == null)
                    throw new UnauthorizedAccessException();

                _user = ClaimsTransformation.Transform(principle);
                
                if (_user == null || _user.Id == Guid.Empty)
                    throw new UnauthorizedAccessException();
                
                return _user;
            }
        }
    }
}

