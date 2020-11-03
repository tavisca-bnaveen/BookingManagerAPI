using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingManager.Services.Interfaces;
using BookingManager.Services.Services;
using CommonModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BookingManager.Controllers
{
	[EnableCors("MyPolicy")]
	[Route("api/[controller]")]
	[ApiController]
	public class ProfileController : Controller
    {
        
		[HttpGet("GetProfile")]
		public ActionResult<IEnumerable<Profile>> GetProfile([FromQuery] string Id)
		{
			IProfileService profileService = new ProfileService();
			return Ok(profileService.GetProfileById(Id));
		}
		[HttpPost("UpdateProfile")]
		public ActionResult<IEnumerable<Profile>> UpdateProfile([FromBody] Profile profile)
		{
			IProfileService profileService = new ProfileService();
			return Ok(profileService.UpdateProfileById(profile));
		}

	}
}