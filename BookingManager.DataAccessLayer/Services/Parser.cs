using BookingManager.DataAccessLayer.DBModels;
using BookingManager.DataAccessLayer.Interfaces;
using CommonModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingManager.DataAccessLayer.Services
{
	public class Parser : IParser
	{
		public Flight FlightParser(DBFlight _DBFlight)
		{
			var flight = new Flight();
			flight.PNR = _DBFlight.PNR;
			flight.Type = _DBFlight.Type;
			flight.Source = new List<string>(_DBFlight.Source.Split(','));
			flight.Destination= new List<string>(_DBFlight.Destination.Split(','));
			flight.DeparatureTimes= new List<string>(_DBFlight.DeparatureTimes.Split(','));
			flight.ArrivalTimes= new List<string>(_DBFlight.ArrivalTimes.Split(','));
			flight.Status = _DBFlight.Status;
			flight.Cost = _DBFlight.Cost;
			flight.Discount = _DBFlight.Discount;
			flight.PassengerCount = _DBFlight.PassengerCount;
			flight.AirlineDetails= new List<string>(_DBFlight.AirlineDetails.Split(','));
			return flight;
		}


	}
}
