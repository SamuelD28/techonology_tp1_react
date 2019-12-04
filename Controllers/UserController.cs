using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
                return ResponseResult.WrongData(new { error = "Email is required" });
            }

            if (string.IsNullOrEmpty(user.PhoneNumber))
            {
                return ResponseResult.WrongData(new { error = "Phone number is required" });
            }

            var result = await UserManager.CreateAsync(
                         new User()
                         {
                             UserName = user.UserName,
                             Email = user.Email,
                             PhoneNumber = user.PhoneNumber,
                         }, user.PasswordHash);

            if (result.Succeeded)
            {
                User savedUser = await UserManager.FindByNameAsync(user.UserName);
                return ResponseResult.CreateValidResponse(new { message = "User is now registered", user = savedUser }, 201);
            }
            else
            {
                return ResponseResult.WrongData(result.Errors);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]User user)
        {
            User foundUser = await UserManager.FindByNameAsync(user.UserName);
            if (foundUser is null)
            {
                return ResponseResult.NoMatchingDocument(new { message = "No username with name of " + user.UserName });
            }

            var result = await SignInManager.CheckPasswordSignInAsync(foundUser, user.PasswordHash, false);

            if (result.Succeeded)
            {
                await SignInManager.SignInAsync(foundUser, true, CookieAuthenticationDefaults.AuthenticationScheme);
                return ResponseResult.CreateValidResponse(new { message = "You are now logged in", user = foundUser }, 200);
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
                return ResponseResult.NoMatchingDocument(new { message = "No username : " + user.UserName });
            }

            await SignInManager.SignOutAsync();
            return ResponseResult.CreateValidResponse(new { message = "You are now logged out" }, 200);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            if (HttpContext.User.Identity.Name is null)
            {
                return ResponseResult.NoMatchingDocument(new { message = "You're not logged" });
            }
            User foundUser = await UserManager.FindByNameAsync(HttpContext.User.Identity.Name);
            return ResponseResult.CreateValidResponse(foundUser, 200);
        }

        [HttpPost("auth")]
        public IActionResult Auth()
        {
            return IsAuth(HttpContext, () =>
            {
                return ResponseResult.CreateValidResponse(new { message = "User is authenticated" }, 200);
            });
        }

        public static IActionResult IsAuth(HttpContext httpContext, Func<IActionResult> next)
        {
            if (httpContext.User.Identity.IsAuthenticated)
            {
                return next();
            }
            else
            {
                return ResponseResult.Forbiden();
            }
        }
    }
}
