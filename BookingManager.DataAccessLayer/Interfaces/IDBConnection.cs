using System;
using System.Collections.Generic;
using System.Text;

namespace BookingManager.DataAccessLayer.Interfaces
{
	interface IDBConnection
	{
		string GetConnectionString();
	}
}
