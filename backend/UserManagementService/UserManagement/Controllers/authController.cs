using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserManagement.Models;
using UserManagement.DTOs;

namespace UserManagement.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly UserContext _dbContext;
		public AuthController(UserContext dbContext)
		{
			_dbContext = dbContext;
		}

		[HttpPost("register")]
		public async Task<ActionResult<User>> Register(User request)
		{
			var (hash, salt) = PasswordHasher.HashPassword(request.Password);

			var user = new User
			{
				FullName = request.FullName,
				status = request.status,
				Email = request.Email,
				CompanyName = request.CompanyName,
				Password = hash,
				PasswordSalt = salt
			};

			_dbContext.Users.Add(user);
			await _dbContext.SaveChangesAsync();

			return Ok(user);
		}

		// Login

		// [HttpGet]
		// [Route("Login")]


		[HttpPost]
		[Route("Login")]
		public async Task<ActionResult<User>> Login(LoginDTO login)
		{
			var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.FullName == login.FullName);

			if (PasswordHasher.VerifyPassword(login.Password, user.Password, user.PasswordSalt))
			{
				// Successful login
				return Ok("Login successful");
			}
			else
			{
				return BadRequest("Invalid username or password");
			}

		}



	}
}