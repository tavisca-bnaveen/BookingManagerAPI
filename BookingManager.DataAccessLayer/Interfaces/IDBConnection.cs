using System;
using System.Text;

namespace BookingManager.DataAccessLayer.Interfaces
{
	interface IDBConnection
	{
		string GetConnectionString();
	}
}
