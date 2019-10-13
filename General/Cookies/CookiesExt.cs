using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Technology_Tp1_React.General.Cookies
{
    /// <summary>
    /// Extension class for cookie manipulation
    /// </summary>
    public static class CookiesExt
    {
        /// <summary>
        /// Method that get a specified cookie from the cookies collection
        /// </summary>
        /// <param name="cookies">Cookie collection</param>
        /// <param name="key">Name of the cookie</param>
        /// <returns>Specified cookie or null</returns>
        public static string Get(this IRequestCookieCollection cookies,  string key)
        {
            return cookies[key];
        }
    
        /// <summary>
        /// Method that set cookie in the cookie collection
        /// </summary>
        /// <param name="cookies">Cookie collection</param>
        /// <param name="key">Name of the cookie</param>
        /// <param name="value">Value of the cookie</param>
        /// <param name="expireTime">Expired date of the cookie</param>
        public static void Set(this IResponseCookies cookies, string key, string value, int? expireTime)
        {
            CookieOptions option = new CookieOptions();
            if (expireTime.HasValue)
                option.Expires = DateTime.Now.AddMinutes(expireTime.Value);
            else
                option.Expires = DateTime.Now.AddMilliseconds(10);
            cookies.Append(key, value, option);
        }

        /// <summary>
        /// Method that remove a cookie from the cookie collection
        /// </summary>
        /// <param name="cookies">Cookie collection</param>
        /// <param name="key">Name of the cookie</param>
        public static void Remove(this IResponseCookies cookies, string key)
        {
            cookies.Delete(key);
        }
    }
}
