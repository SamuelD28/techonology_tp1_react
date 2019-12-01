using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Technology_Tp1_React.General.CrudController;
using Technology_Tp1_React.Models;

namespace technology_tp1.Controllers
{
	[Route("api/user")]
	public class UserController : Controller
	{
		public UserManager<User> UserManager { get; set; }
		public SignInManager<User> SignInManager { get; set; }

		public UserController(
			UserManager<User> userManager,
			SignInManager<User> signInManager)
		{
			UserManager = userManager;
			SignInManager = signInManager;
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
				return Ok(savedUser);
			}
			else
			{
				return ErrorResponse.WrongData(result.Errors);
			}
		}

		[HttpPost("auth")]
		public async Task<IActionResult> Auth([FromBody]User user)
		{
			var foundUser = await UserManager.FindByNameAsync(user.UserName);

			if (foundUser == null)
			{
				return ErrorResponse.NoMatchingDocument(new { message = "No username : " + user.UserName });
			}

			var result = await SignInManager.CheckPasswordSignInAsync(foundUser, user.PasswordHash, false);
			return result.Succeeded
				? Json(new { isAuth = true })
				: Json(new { isAuth = false });
		}
	}
}
