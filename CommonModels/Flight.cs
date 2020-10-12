using System.Collections.Generic;

namespace CommonModels
{
	public class Flight
	{
		public string PNR { get; set; }
		public string Type { get; set; }
		public List<string> Source { get; set; }
		public List<string> Destination { get; set; }
		public List<string> DeparatureTimes { get; set; }
		public List<string> ArrivalTimes { get; set; }
		public	List<string> AirlineDetails { get; set; }
		public string Status { get; set; }

		public string Cost { get; set; }
		public string Discount { get; set; }
		public string PassengerCount { get; set; }
	}
}
