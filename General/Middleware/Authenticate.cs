using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using Technology_Tp1_React.General.CrudController;
using Technology_Tp1_React.Models;

namespace Technology_Tp1_React.General.Middleware
{
    public class Authenticate
    {
        public UserManager<User> UserManager { get; set; }
        public RoleManager<IdentityRole> RoleManager { get; set; }

        public Authenticate(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            UserManager = userManager;
            RoleManager = roleManager;
        }

        public IActionResult Apply(HttpContext httpContext, string roleAuthorized, Func<IActionResult> next)
        {
            if (httpContext.User.Identity.IsAuthenticated)
            {
                User connectedUser = UserManager.FindByNameAsync(httpContext.User.Identity.Name).Result;

                if(roleAuthorized != null)
                {
                    if (UserManager.IsInRoleAsync(connectedUser, roleAuthorized).Result)
                    {
                        httpContext.Items["user"] = connectedUser;
                        return next();
                    }
                }
                else
                {
                    httpContext.Items["user"] = connectedUser;
                    return next();
                }
            }

            return ResponseResult.Forbiden();
        }
    }
}
