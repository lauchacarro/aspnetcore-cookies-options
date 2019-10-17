using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
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
            file = @enum switch
            {
                PageEnum.Index => Path.Combine(file, "index.html"),
                PageEnum.SeeCookie => Path.Combine(file, "seecookies.html"),
                PageEnum.Forbidden => Path.Combine(file, "403.html"),
                _ => throw new InvalidEnumArgumentException(nameof(PageResult) + ".@enum", (int)@enum, typeof(PageEnum)),
            };
            return file;
        }

    }
}
