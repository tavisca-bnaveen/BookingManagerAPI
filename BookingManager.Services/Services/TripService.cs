using BookingManager.DataAccessLayer.Services;
using BookingManager.Services.Interfaces;
using CommonModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingManager.Services.Services
{
	public class TripService : ITripService
	{
		PostOperations _PostOperations;
		public TripService()
		{
			_PostOperations = new PostOperations();
		}
		public bool CancelFlight(string tripId, string PNR)
		{
			return _PostOperations.CancelFlight(tripId, PNR);
		}

		public bool CancelHotel(string tripId, string Id)
		{
			return _PostOperations.CancelHotel(tripId, Id);
		}

		public bool CancelCar(string tripId, string Id)
		{
			return _PostOperations.CancelCar(tripId, Id);
		}

		public List<Trip> GetTrips()
		{
			
			var trips = new List<Trip>();
			foreach(var trip in _PostOperations.GetAllTrips())
			{
				trip.TotalCost = CalculateAmount(trip.Flight, trip.Car, trip.Hotel);
				trip.Status = CalculateStatus(trip.Flight, trip.Car, trip.Hotel);
				trips.Add(trip);
			}
			return trips;
		}
		public string GetFlightStatus(string TripId, string PNR)
		{
			return _PostOperations.GetFlightStatus(TripId, PNR);
		}
		public string GetHotelStatus(string TripId, string Id)
		{
			return _PostOperations.GetHotelStatus(TripId, Id);
		}
		public string GetCarStatus(string TripId, string Id)
		{
			return _PostOperations.GetCarStatus(TripId, Id);
		}
		private string CalculateAmount(Flight flight, List<Car> cars, List<Hotel> hotels)
		{
			double amount = 0;
			if(flight!=null)
				amount += (double.Parse(flight.Cost) - double.Parse(flight.Discount));
			foreach (var car in cars)
			{
				amount += (double.Parse(car.Cost) - double.Parse(car.Discount));
			}
			foreach (var hotel in hotels)
			{
				amount += (double.Parse(hotel.Cost) - double.Parse(hotel.Discount));
			}

			return amount.ToString();
		}
		private string CalculateStatus(Flight flight, List<Car> cars, List<Hotel> hotels)
		{
			int cancelCount = 0, confirmCount = 0;

			if (flight!=null&&flight.Status.ToLower() == "cancel")
			{
				cancelCount += 1;
			}
			else if (flight != null && flight.Status.ToLower() == "confirm")
			{
				confirmCount += 1;
			}
			else if(flight != null)
			{
				return flight.Status;
			}
			foreach (var car in cars)
			{
				if (car.Status.ToLower() == "cancel")
				{
					cancelCount += 1;
				}
				else
				{
					confirmCount += 1;
				}
			}
			foreach (var hotel in hotels)
			{
				if (hotel.Status.ToLower() == "cancel")
				{
					cancelCount += 1;
				}
				else
				{
					confirmCount += 1;
				}
			}
			if (cancelCount == 0)
			{
				return "Confirm";
			}
			else if (confirmCount == 0)
			{
				return "Cancel";
			}
			else
			{
				return "PartialCancelled";
			}
		}
	}
}
