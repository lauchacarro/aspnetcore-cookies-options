using aspnetcore_cookies_options.Authorization;
using aspnetcore_cookies_options.Pages;
using Microsoft.AspNetCore.Mvc;

namespace aspnetcore_cookies_options.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {
        public IActionResult Home()
        {
            return new PageResult(PageEnum.Index);
        }


        [Authorize]
        [Route("[action]")]
        public IActionResult SeeCookies()
        {
            return new PageResult(PageEnum.SeeCookie);
        }
    }
}
