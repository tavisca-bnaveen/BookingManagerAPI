using CommonModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingManager.Services.Interfaces
{
	public interface ITripService
	{
		List<Trip> GetTrips();

		bool CancelFlight(string tripId, string PNR);
		bool CancelHotel(string tripId, string Id);
		bool CancelCar(string tripId, string Id);
	}
}
