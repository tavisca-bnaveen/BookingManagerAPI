using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingManager.Services.Interfaces;

using BookingManager.Services.Services;
using CommonModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace BookingManager.Controllers
{
	[EnableCors("MyPolicy")]
	[Route("api/[controller]")]
	[ApiController]
	public class LoginController : Controller
    {
		[HttpGet]
		public ActionResult<IEnumerable<string>> Get()
		{
			return Ok("HI");
		}
		[HttpPost]
		public ActionResult<IEnumerable<bool>> Post([FromBody]Login login)
		{
			ILoginService service = new LoginService();

			return Ok(service.GetAuthentiction(login));
		}
		[HttpPost("SignUp")]
		public ActionResult<IEnumerable<string>> SignUp([FromBody]Login login)
		{
			ILoginService service = new LoginService();

			return Ok(service.Signup(login));
		}
		[HttpGet("AllUsers")]
		public ActionResult<IEnumerable<List<Login>>> AllUsers()
		{
			ILoginService service = new LoginService();
			return Ok(service.GetUsers());
		}

	}
}