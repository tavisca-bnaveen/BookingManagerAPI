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
		[HttpDelete("CancelFlight")]
		public ActionResult<bool> CancelFlight([FromQuery] string TripId, [FromQuery] string PNR)
		{
			ITripService tripService = new TripService();
			var output = tripService.CancelFlight(TripId, PNR);
			if (output)
			{
				return Ok(output);
			}
			else
			{
				return BadRequest(output);
			}
		}

		[HttpDelete("CancelHotel")]
		public ActionResult<bool> CancelHotel([FromQuery] string TripId, [FromQuery] string Id)
		{
			ITripService tripService = new TripService();
			var output = tripService.CancelHotel(TripId, Id);
			if (output)
			{
				return Ok(output);
			}
			else
			{
				return BadRequest(output);
			}
		}

		[HttpDelete("CancelCar")]
		public ActionResult<bool> CancelCar([FromQuery] string TripId, [FromQuery] string Id)
		{
			ITripService tripService = new TripService();
			var output = tripService.CancelCar(TripId, Id);
			if (output)
			{
				return Ok(output);
			}
			else
			{
				return BadRequest(output);
			}
		}
	}
}