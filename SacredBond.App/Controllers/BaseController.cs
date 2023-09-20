using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SacredBond.Common.Security;
using System.Security.Claims;
using System.Security.Principal;

namespace SacredBond.App.Controllers
{
    [Authorize]
    public abstract class BaseController : Controller
    {
        protected readonly ILogger _logger;
        private readonly IPrincipal _principal;

        public BaseController(ILogger logger, IPrincipal principal)
        {
            _logger = logger;
            _principal = principal;
        }

        private AppPrincipal _user;
        protected AppPrincipal User
        {
            get
            {
                if (_user != null)
                    return _user;

                var principle = _principal as ClaimsPrincipal;
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
