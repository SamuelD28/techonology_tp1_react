using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Technology_Tp1_React.General.Cookies
{
    public static class CookiesExt
    {
        public static string Get(this IRequestCookieCollection cookies,  string key)
        {
            return cookies[key];
        }

        public static void Set(this IResponseCookies cookies, string key, string value, int? expireTime)
        {
            CookieOptions option = new CookieOptions();
            if (expireTime.HasValue)
                option.Expires = DateTime.Now.AddMinutes(expireTime.Value);
            else
                option.Expires = DateTime.Now.AddMilliseconds(10);
            cookies.Append(key, value, option);
        }

        public static void Remove(this IResponseCookies cookies, string key)
        {
            cookies.Delete(key);
        }
    }
}
