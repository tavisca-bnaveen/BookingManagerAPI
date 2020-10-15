using BookingManager.DataAccessLayer.Interfaces;
using CommonModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingManager.DataAccessLayer.Services
{
	public class PostOperations : IPostOperations
	{
		TripOperations _TripOperations;
		Parser _Parser;
		public PostOperations()
		{
			_TripOperations = new TripOperations();
			_Parser = new Parser();
		}

		public List<Trip> GetAllTrips()
		{
			var dbtrips = _TripOperations.GetAllTrips();
			var _Trips = new List<Trip>();
			foreach(var trip in dbtrips)
			{
				var _Trip = new Trip();
				var _cars = new List<Car>();
				var _hotels = new List<Hotel>();
				_Trip.Id = trip.Id;
				_Trip.BookedDate = trip.BookedDate;
				if(trip.Flight.Length>0)
					_Trip.Flight =  _Parser.FlightParser(_TripOperations.GetFlight(trip.Flight));
				var hotelIds = trip.Hotel.Split(',');
				foreach(var  Id in hotelIds)
				{
					_hotels.Add(_TripOperations.GetHotel(Id));
				}
				_Trip.Hotel = _hotels;
				var CarIds = trip.Car.Split(',');
				foreach (var Id in CarIds)
				{
					_cars.Add(_TripOperations.GetCar(Id));
				}
				_Trip.Car = _cars;
				_Trips.Add(_Trip);
				
			}
			return _Trips;
		}
		public bool CancelFlight(string TripId, string PNR)
		{
			
			return _TripOperations.CancelFlight(TripId, PNR);
		}
		public bool CancelHotel(string TripId, string Id)
		{

			return _TripOperations.CancelHotel(TripId, Id);
		}
		public bool CancelCar(string TripId, string Id)
		{

			return _TripOperations.CancelCar(TripId, Id);
		}

	}
}
