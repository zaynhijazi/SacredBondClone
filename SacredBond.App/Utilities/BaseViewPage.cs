using Microsoft.AspNetCore.Mvc.Razor;
using SacredBond.Common.Security;

namespace SacredBond.App.Utilities
{
    public abstract class BaseViewPage<TModel> : RazorPage<TModel>
    {
        public AppPrincipal? AppUser
        {
            get
            {
                return ClaimsTransformation.Transform(User);
            }
        }
    }
}
