using CommonModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingManager.Services.Interfaces
{
	public interface ITripService
	{
		List<Trip> GetTrips();
	}
}
