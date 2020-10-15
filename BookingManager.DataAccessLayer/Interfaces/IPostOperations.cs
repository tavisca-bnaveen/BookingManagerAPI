using CommonModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingManager.DataAccessLayer.Interfaces
{
	public interface IPostOperations
	{
		List<Trip> GetAllTrips();

		bool CancelFlight(string TripId, string PNR);
		bool CancelHotel(string TripId, string Id);
		bool CancelCar(string TripId, string Id);
		string GetFlightStatus(string TripId, string PNR);
		string GetHotelStatus(string TripId, string Id);
		string GetCarStatus(string TripId, string Id);
	}
}
