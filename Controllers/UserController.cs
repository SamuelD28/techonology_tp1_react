using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Nancy.Json;
using Technology_Tp1_React.General.CrudController;
using Technology_Tp1_React.Models;

namespace technology_tp1.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : Controller
    {
        public UserManager<User> UserManager { get; set; }
        public SignInManager<User> SignInManager { get; set; }
        public IConfiguration Configuration { get; set; }

        public UserController(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IConfiguration configuration
        )
        {
            UserManager = userManager;
            SignInManager = signInManager;
            Configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]User user)
        {
            if (string.IsNullOrEmpty(user.Email))
            {
                return ErrorResponse.WrongData(new { error = "Email is required" });
            }

            var result = await UserManager.CreateAsync(
                         new User()
                         {
                             UserName = user.UserName,
                             Email = user.Email
                         }, user.PasswordHash);
            if (result.Succeeded)
            {
                User savedUser = await UserManager.FindByNameAsync(user.UserName);
                JsonResult response = Json(savedUser);
                return Ok(response);
            }
            else
            {
                return ErrorResponse.WrongData(result.Errors);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]User user)
        {
            User foundUser = await UserManager.FindByNameAsync(user.UserName);
            if (foundUser is null)
            {
                return ErrorResponse.NoMatchingDocument(new { message = "No username : " + user.UserName });
            }

            var result = await SignInManager.CheckPasswordSignInAsync(foundUser, user.PasswordHash, false);

            if (result.Succeeded)
            {
                await SignInManager.SignInAsync(foundUser, true, CookieAuthenticationDefaults.AuthenticationScheme);
                JsonResult response = Json(new { message = "You are now logged in" });
                return Ok(response);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody]User user)
        {
            User foundUser = await UserManager.FindByNameAsync(user.UserName);
            if (foundUser is null)
            {
                return ErrorResponse.NoMatchingDocument(new { message = "No username : " + user.UserName });
            }

            await SignInManager.SignOutAsync();
            JsonResult response = Json(new { message = "You are now logged out" });
            return Ok(response);
        }

        [HttpPost("auth")]
        public async static void IsAuth(HttpContext httpContext, Func<Task> next)
        {
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            if (httpContext.User.Identity.IsAuthenticated)
            {
                await next();
            }
            else
            {
                JsonResult content = new JsonResult(new { isAuth = false });
                httpContext.Response.StatusCode = 403;
                httpContext.Response.ContentType = "application/json";
                await httpContext.Response.WriteAsync(javaScriptSerializer.Serialize(content));
            }
        }
    }
}
