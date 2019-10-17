using aspnetcore_cookies_options.Commons;
using Microsoft.AspNetCore.Http;
using System;

namespace aspnetcore_cookies_options.Extensions
{
    public static class HttpExtension
    {

        public static HttpRequest ExistTokenCookie(this HttpRequest request, Action<string> callback)
        {
            if (request.Cookies.TryGetValue(Constants.COOKIENAME, out string value))
                callback(value);
            return request;
        }
        public static HttpRequest NoExistTokenCookie(this HttpRequest request, Action callback)
        {
            if (!request.Cookies.TryGetValue(Constants.COOKIENAME, out string _))
                callback();
            return request;
        }
    }
}
