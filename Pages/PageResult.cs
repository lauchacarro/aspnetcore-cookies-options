using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace aspnetcore_cookies_options.Pages
{
    public class PageResult : PhysicalFileResult
    {
        public PageResult(PageEnum @enum) : base(ResolveFile(@enum), "text/html")
        {

        }

        private static string ResolveFile(PageEnum @enum)
        {
            string file = Path.Combine(Directory.GetCurrentDirectory(), "Pages", "Html");
            switch (@enum)
            {
                case PageEnum.Index:
                    file = Path.Combine(file, "index.html");
                    break;
                case PageEnum.SeeCookie:
                    file = Path.Combine(file, "seecookies.html");
                    break;
                case PageEnum.Forbidden:
                    file = Path.Combine(file, "403.html");
                    break;
            }
            return file;
        }

    }
}
