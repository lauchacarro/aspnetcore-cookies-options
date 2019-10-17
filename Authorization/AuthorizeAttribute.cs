using Microsoft.AspNetCore.Mvc;

namespace aspnetcore_cookies_options.Authorization
{
    public class AuthorizeAttribute : TypeFilterAttribute
    {
        public AuthorizeAttribute() : base(typeof(AuthorizeRequirementFilter))
        {

        }
    }
}
