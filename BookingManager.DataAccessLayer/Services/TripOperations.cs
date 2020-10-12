using BookingManager.DataAccessLayer.DBModels;
using BookingManager.DataAccessLayer.Interfaces;
using CommonModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace BookingManager.DataAccessLayer.Services
{
	public class TripOperations : ITripOperations
	{
		private string _ConnectionString = null;
		private SqlConnection _SqlConnection;
		private SqlCommand _SqlCommand;
		public TripOperations()
		{
			IDBConnection dBConnection = new DBConnection();
			_ConnectionString = dBConnection.GetConnectionString();
			_SqlConnection = new SqlConnection(_ConnectionString);
		}
		public List<DBTrip> GetAllTrips()
		{
			var _Trips= new List<DBTrip>();

			try
			{
				_SqlConnection.Open();
				using (_SqlCommand = new SqlCommand("Select * from Trip", _SqlConnection))
				{
					var reader = _SqlCommand.ExecuteReader();
					if (reader.HasRows)
					{
						while (reader.Read())
						{
							var _Trip = new DBTrip();
							_Trip.Id = reader[0].ToString();
							_Trip.BookedDate = reader[1].ToString();
							_Trip.Flight = reader[2].ToString();
							_Trip.Hotel = reader[3].ToString();
							_Trip.Car = reader[4].ToString();
							_Trips.Add(_Trip);
						}
						
					}
				}
				
			}
			finally
			{
				_SqlConnection.Close();
			}

			return _Trips;
		}

		public Car GetCar(string _CarId)
		{
			Car _Car= new Car();

			try
			{
				_SqlConnection.Open();
				using (_SqlCommand = new SqlCommand("Select * from Car where id='"+_CarId+"'", _SqlConnection))
				{
					var reader = _SqlCommand.ExecuteReader();
					if (reader.HasRows)
					{
						while (reader.Read())
						{
							_Car.Id = reader[0].ToString();
							_Car.Name = reader[1].ToString();
							_Car.PickUp = reader[2].ToString();
							_Car.DropOff = reader[3].ToString();
							_Car.Pickupdate = reader[4].ToString();
							_Car.DropOffDate = reader[5].ToString();
							_Car.Cost = reader[6].ToString();
							_Car.Discount = reader[7].ToString();
							_Car.Status = reader[8].ToString();
						}

					}
				}

			}
			finally
			{
				_SqlConnection.Close();
			}


			return _Car;
		
		}

		public DBFlight GetFlight(string PNR)
		{
			DBFlight dBFlight = new DBFlight();

			try
			{
				_SqlConnection.Open();
				using (_SqlCommand = new SqlCommand("Select * from Flight where PNR='" + PNR + "'", _SqlConnection))
				{
					var reader = _SqlCommand.ExecuteReader();
					if (reader.HasRows)
					{
						while (reader.Read())
						{
							dBFlight.PNR = reader[0].ToString();
							dBFlight.Type = reader[1].ToString();
							dBFlight.Source = reader[2].ToString();
							dBFlight.Destination = reader[3].ToString();
							dBFlight.DeparatureTimes = reader[4].ToString();
							dBFlight.ArrivalTimes = reader[5].ToString();
							dBFlight.Status = reader[6].ToString();
							dBFlight.Cost = reader[7].ToString();
							dBFlight.Discount = reader[8].ToString();
							dBFlight.PassengerCount = reader[9].ToString();
							dBFlight.AirlineDetails = reader[10].ToString();
						}

					}
				}

			}
			finally
			{
				_SqlConnection.Close();
			}


			return dBFlight;

		}

		public Hotel GetHotel(string _HotelId)
		{
			Hotel _Hotel = new Hotel();

			try
			{
				_SqlConnection.Open();
				using (_SqlCommand = new SqlCommand("Select * from Hotel where id='" + _HotelId + "'", _SqlConnection))
				{
					var reader = _SqlCommand.ExecuteReader();
					if (reader.HasRows)
					{
						while (reader.Read())
						{
							_Hotel.Id = reader[0].ToString();
							_Hotel.CheckIn = reader[1].ToString();
							_Hotel.Checkout = reader[2].ToString();
							_Hotel.Location = reader[3].ToString();
							_Hotel.Name = reader[4].ToString();
							_Hotel.Cost = reader[5].ToString();
							_Hotel.Discount = reader[6].ToString();
							_Hotel.PeopleCount = reader[7].ToString();
							_Hotel.TravellerInfo = reader[8].ToString();
							_Hotel.Rating = reader[9].ToString();
							_Hotel.Status = reader[10].ToString();
						}

					}
				}

			}
			finally
			{
				_SqlConnection.Close();
			}


			return _Hotel;

		}
	}
}
