using aspnetcore_cookies_options.Commons;
using aspnetcore_cookies_options.Extensions;
using aspnetcore_cookies_options.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace aspnetcore_cookies_options.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Login([FromForm] LoginModel model)
        {

            IActionResult result = null;

            model.IsSuccess(() =>
            {
                CookieOptions options = new CookieOptions
                {
                    HttpOnly = true,
                    SameSite = SameSiteMode.Strict,
                    Secure = true,
                    Expires = DateTime.Now.AddHours(24)
                };

                Response.Cookies.Append(Constants.COOKIENAME, JsonSerializer.Serialize(model), options);

                result = Redirect("/SeeCookies");

            })
            .IsError(() =>
            {
                result = Redirect("/?loginresult=false");


            });

            return result;

        }


    }
}
