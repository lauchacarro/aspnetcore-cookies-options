using aspnetcore_cookies_options.Commons;
using aspnetcore_cookies_options.Extensions;
using aspnetcore_cookies_options.Models;
using aspnetcore_cookies_options.Pages;
using Microsoft.AspNetCore.Mvc.Filters;

namespace aspnetcore_cookies_options.Authorization
{
    public class AuthorizeRequirementFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            context.HttpContext.Request.ExistTokenCookie(token =>
            {
                LoginModel model = System.Text.Json.JsonSerializer.Deserialize<LoginModel>(token);

                model.IsError(() =>
                {
                    context.HttpContext.Response.Cookies.Delete(Constants.COOKIENAME);

                    context.Result = new PageResult(PageEnum.Forbidden);

                });

            })
            .NoExistTokenCookie(() =>
            {
                context.Result = new PageResult(PageEnum.Forbidden);
            });
        }
    }
}
