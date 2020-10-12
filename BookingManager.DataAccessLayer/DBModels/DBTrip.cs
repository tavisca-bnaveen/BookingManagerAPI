using System;
using System.Collections.Generic;
using System.Text;

namespace BookingManager.DataAccessLayer.DBModels
{
	public class DBTrip
	{
		public string Id { get; set; }
		public string BookedDate { get; set; }
		public string Flight { get; set; }
		public string  Car { get; set; }
		public string Hotel { get; set; }
	}
}
