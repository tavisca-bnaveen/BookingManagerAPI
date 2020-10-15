using BookingManager.DataAccessLayer.DBModels;
using CommonModels;
using System.Collections.Generic;

namespace BookingManager.DataAccessLayer.Interfaces
{
	interface ITripOperations
	{
		List<DBTrip> GetAllTrips();

		DBFlight GetFlight(string PNR);

		Hotel GetHotel(string _HotelId);

		Car GetCar(string _CarId);

		bool CancelFlight(string TripId, string PNR);
		bool CancelCar(string TripId, string Id);
		bool CancelHotel(string TripId, string Id);
		string GetFlightStatus(string TripId, string PNR);
		string GetHotelStatus(string TripId, string Id);
		string GetCarStatus(string TripId, string Id);
	}
}
