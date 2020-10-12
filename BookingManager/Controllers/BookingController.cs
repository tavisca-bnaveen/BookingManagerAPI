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
	public class BookingController : Controller
    {
		[HttpGet("GetAllTrips")]
		public ActionResult<List<Trip>> GetAllTrips()
		{
			ITripService tripService = new TripService();
			return Ok(tripService.GetTrips());
		}
	}
}