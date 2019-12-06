using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Technology_Tp1_React.General.CrudController;
using Technology_Tp1_React.General.Middleware;
using Technology_Tp1_React.Models;

namespace technology_tp1.Controllers
{
    [Route("api/user")]
	public class UserController : Controller
	{
		public Authenticate Authenticate { get; set; }
		public UserManager<User> UserManager { get; set; }
        public RoleManager<IdentityRole> RoleManager { get; set; }
        public SignInManager<User> SignInManager { get; set; }

		public UserController(
			UserManager<User> userManager,
			SignInManager<User> signInManager,
            RoleManager<IdentityRole> roleManager,
			Authenticate authenticate
		)
		{
			Authenticate = authenticate;
			UserManager = userManager;
			SignInManager = signInManager;
            RoleManager = roleManager;
            CreateRoles();
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
            
            User newUser = await CreateUserAsync(user, new[] { "Administrator", "Client", "Delivery" });

			if (newUser != null)
			{
				return ResponseResult.CreateValidResponse(new { message = "User is now registered", user = newUser }, 201);
			}
			else
			{
				return ResponseResult.WrongData();
			}
		}

        [HttpPost("register/client")]
        public async Task<IActionResult> RegisterClient([FromBody]User user)
        {
            if (string.IsNullOrEmpty(user.Email))
            {
                return ResponseResult.WrongData(new { error = "Email is required" });
            }

            if (string.IsNullOrEmpty(user.PhoneNumber))
            {
                return ResponseResult.WrongData(new { error = "Phone number is required" });
            }

            User newUser = await CreateUserAsync(user, new[] { "Client" });

            if (newUser != null)
            {
                return ResponseResult.CreateValidResponse(new { message = "User is now registered", user = newUser }, 201);
            }
            else
            {
                return ResponseResult.WrongData();
            }
        }

        [HttpPost("register/delivery")]
        public async Task<IActionResult> RegisterDelivery([FromBody]User user)
        {
            if (string.IsNullOrEmpty(user.Email))
            {
                return ResponseResult.WrongData(new { error = "Email is required" });
            }

            if (string.IsNullOrEmpty(user.PhoneNumber))
            {
                return ResponseResult.WrongData(new { error = "Phone number is required" });
            }

            User newUser = await CreateUserAsync(user, new[] { "Delivery" });

            if (newUser != null)
            {
                return ResponseResult.CreateValidResponse(new { message = "User is now registered", user = newUser }, 201);
            }
            else
            {
                return ResponseResult.WrongData();
            }
        }

        [HttpPost("login")]
		public IActionResult Login([FromBody]User user)
		{
			User foundUser = UserManager.FindByNameAsync(user.UserName).Result;

			if (foundUser is null)
			{
				return ResponseResult.NoMatchingDocument(new { message = "No username with name of " + user.UserName });
			}

			var result = SignInManager.CheckPasswordSignInAsync(foundUser, user.PasswordHash, false).Result;

			if (result.Succeeded)
			{
				SignInManager.SignInAsync(foundUser, true, CookieAuthenticationDefaults.AuthenticationScheme).Wait();
				return ResponseResult.CreateValidResponse(new { message = "You are now logged in", user = foundUser }, 200);
			}
			else
			{
				return NotFound();
			}
		}

		[HttpGet("logout")]
		public IActionResult Logout()
		{
			return Authenticate.Apply(HttpContext, null, () => {
				
				SignInManager.SignOutAsync().Wait();
				return ResponseResult.CreateValidResponse(new { message = "You are now logged out" }, 200);
			});
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

		[HttpGet("auth")]
		public IActionResult Auth()
		{
			return Authenticate.Apply(HttpContext, null, () =>
			{
				User currentUser = (User)HttpContext.Items["user"];
				return ResponseResult.CreateValidResponse(new { message = "User is authenticated", user = currentUser }, 200);
			});
		}

        public async Task CreateRoleIfNotExist(string roleName)
        {
            if (!await RoleManager.RoleExistsAsync(roleName))
            {
                await RoleManager.CreateAsync(new IdentityRole(roleName));

            }
        }

        public async Task<User> CreateUserAsync(User user, IEnumerable<string> roles)
        {
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
                await UserManager.AddToRolesAsync(savedUser, roles);
                return user;
            }

            return null;
        }

        public async Task CreateRoles()
        {
            await CreateRoleIfNotExist("Administrator");
            await CreateRoleIfNotExist("Client");
            await CreateRoleIfNotExist("Delivery");
        }
	}
}
