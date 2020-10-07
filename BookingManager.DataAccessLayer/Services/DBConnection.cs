using BookingManager.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingManager.DataAccessLayer.Services
{
	class DBConnection : IDBConnection
	{

		string _connection = "Data Source=.;initial catalog = BookingManager; User Id = sa; password=test123!@#";
		public string GetConnectionString()
		{
			return _connection;
		}
	}
}
