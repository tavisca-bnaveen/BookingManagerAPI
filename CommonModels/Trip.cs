using System.Collections.Generic;

namespace CommonModels
{
	public class Trip
	{
		public string Id { get; set; }
		public string BookedDate { get; set; }
		public Flight Flight { get; set; }
		public List<Hotel> Hotel { get; set; }

		public List<Car> Car { get; set; }

		public string TotalCost { get; set; }
		public string Status { get; set; }
	}
}
