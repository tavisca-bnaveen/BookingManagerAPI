using CommonModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingManager.DataAccessLayer.Interfaces
{
	public interface IPostOperations
	{
		List<Trip> GetAllTrips();
	}
}
