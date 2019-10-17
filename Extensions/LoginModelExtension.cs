using aspnetcore_cookies_options.Commons;
using aspnetcore_cookies_options.Models;
using System;

namespace aspnetcore_cookies_options.Extensions
{
    public static class LoginModelExtension
    {

        public static LoginModel IsSuccess(this LoginModel model, Action callback)
        {
            if (model.Username == Constants.USERNAME && model.Password == Constants.PASSWORD)
                callback();
            return model;
        }

        public static LoginModel IsError(this LoginModel model, Action callback)
        {
            if (model.Username != Constants.USERNAME || model.Password != Constants.PASSWORD)
                callback();
            return model;
        }
    }
}
