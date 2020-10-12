using BookingManager.DataAccessLayer.DBModels;
using CommonModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingManager.DataAccessLayer.Interfaces
{
	public interface IParser
	{
		//Trip TripParser(DBTrip _DBTrip);

		Flight FlightParser(DBFlight _DBFlight);
	}
}
