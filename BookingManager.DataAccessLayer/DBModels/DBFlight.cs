using System;
using System.Collections.Generic;
using System.Text;

namespace BookingManager.DataAccessLayer.DBModels
{
	public class DBFlight
	{
		public string PNR { get; set; }
		public string Type { get; set; }
		public string Source { get; set; }
		public string Destination { get; set; }
		public string DeparatureTimes { get; set; }
		public string ArrivalTimes { get; set; }
		public string AirlineDetails { get; set; }
		public string Status { get; set; }

		public string Cost { get; set; }
		public string Discount { get; set; }
		public string PassengerCount { get; set; }
	}
}
