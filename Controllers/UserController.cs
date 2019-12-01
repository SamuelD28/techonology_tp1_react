using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Technology_Tp1_React.General.CrudController;
using Technology_Tp1_React.Models;

namespace technology_tp1.Controllers
{
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
				return Ok(savedUser);
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
				string tokenValue = GenerateJwtToken(foundUser.Email, foundUser);
				Response.Cookies.Append("pizzeria_auth", tokenValue);
				return Ok();
			}
			else
			{
				return NotFound();
			}
		}

		/// <summary>
		///	Method taken from https://medium.com/@ozgurgul/asp-net-core-2-0-webapi-jwt-authentication-with-identity-mysql-3698eeba6ff8
		/// </summary>
		/// <param name="email"></param>
		/// <param name="user"></param>
		/// <returns></returns>
		private string GenerateJwtToken(string email, IdentityUser user)
		{
			List<Claim> claims = new List<Claim>
			{
				new Claim(JwtRegisteredClaimNames.Sub, email),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				new Claim(ClaimTypes.NameIdentifier, user.Id)
			};

			SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtKey"]));
			SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
			DateTime expires = DateTime.Now.AddDays(Convert.ToDouble(Configuration["JwtExpireDays"]));

			JwtSecurityToken token = new JwtSecurityToken(
				Configuration["JwtIssuer"],
				Configuration["JwtIssuer"],
				claims,
				expires: expires,
				signingCredentials: creds
			);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}
