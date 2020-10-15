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
		ITripService _tripService;
		public BookingController()
		{
			_tripService = new TripService();
		}

		[HttpGet("GetAllTrips")]
		public ActionResult<List<Trip>> GetAllTrips()
		{
			
			return Ok(_tripService.GetTrips());
		}
		[HttpDelete("CancelFlight")]
		public ActionResult<bool> CancelFlight([FromQuery] string TripId, [FromQuery] string PNR)
		{
			
			var output = _tripService.CancelFlight(TripId, PNR);
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
			
			var output = _tripService.CancelHotel(TripId, Id);
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
			
			var output = _tripService.CancelCar(TripId, Id);
			if (output)
			{
				return Ok(output);
			}
			else
			{
				return BadRequest(output);
			}
		}
		[HttpGet("GetFlightStatus")]
		public ActionResult<string> GetFlightStatus([FromQuery] string TripId, [FromQuery] string PNR)
		{
			return Ok(_tripService.GetFlightStatus(TripId, PNR));
		}
		[HttpGet("GetHotelStatus")]
		public ActionResult<string> GetHotelStatus([FromQuery] string TripId, [FromQuery] string Id)
		{
			return Ok(_tripService.GetHotelStatus(TripId, Id));
		}
		[HttpGet("GetCarStatus")]
		public ActionResult<string> GetCarStatus([FromQuery] string TripId, [FromQuery] string Id)
		{
			return Ok(_tripService.GetCarStatus(TripId, Id));
		}
	}
}