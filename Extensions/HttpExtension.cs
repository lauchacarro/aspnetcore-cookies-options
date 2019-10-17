using aspnetcore_cookies_options.Commons;
using Microsoft.AspNetCore.Http;
using System;

namespace aspnetcore_cookies_options.Extensions
{
    public static class HttpExtension
    {

        public static HttpRequest HasTokenCookie(this HttpRequest request, Action<string> callback)
        {
            if (request.Cookies.TryGetValue(Constants.COOKIENAME, out string value))
                callback(value);
            return request;
        }
        public static HttpRequest HasNotTokenCookie(this HttpRequest request, Action callback)
        {
            if (!request.Cookies.TryGetValue(Constants.COOKIENAME, out string _))
                callback();
            return request;
        }
    }
}
