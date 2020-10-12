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
		public List<Trip> GetTrips()
		{
			PostOperations postOperations = new PostOperations();
			var trips = new List<Trip>();
			foreach(var trip in postOperations.GetAllTrips())
			{
				trip.TotalCost = CalculateAmount(trip.Flight, trip.Car, trip.Hotel);
				trip.Status = CalculateStatus(trip.Flight, trip.Car, trip.Hotel);
				trips.Add(trip);
			}
			return trips;
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
