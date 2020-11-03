using BookingManager.DataAccessLayer.Interfaces;
using CommonModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace BookingManager.DataAccessLayer.Services
{
	public class DbProfileService : IProfile
	{

		private string _ConnectionString = null;
		private SqlConnection _SqlConnection;
		private SqlCommand _SqlCommand;

		public DbProfileService()
		{

			IDBConnection dBConnection = new DBConnection();
			_ConnectionString = dBConnection.GetConnectionString();
			_SqlConnection = new SqlConnection(_ConnectionString);

		}

		public bool CreateProfile(Profile profile)
		{
			try
			{
				_SqlConnection.Open();

				using (var sqlCommand = new SqlCommand("insert into Profile values('"+profile.Email+"', '"+profile.Name+"', '"+profile.Age+"', '"+profile.Hobbies+"', '"+profile.Gender+"', '"+profile.Joined+"')", _SqlConnection))
				{
					var reader = sqlCommand.ExecuteNonQuery();
					if (reader > 0)
					{
						return true;
					}
					else
					{
						return false;
					}

				}
			}
			catch(Exception ex)
			{
				return false;
			}
			finally
			{
				_SqlConnection.Close();
			}

		}

		public Profile GetProfileById(string Id)
		{
			Profile profile=null;
			try
			{
				_SqlConnection.Open();
				
				using(var sqlCommand = new SqlCommand("Select * from Profile where Email='"+Id+"'", _SqlConnection))
				{
					var reader=sqlCommand.ExecuteReader();
					if (reader.HasRows)
					{
						while (reader.Read())
						{
							profile = new Profile();
							profile.Email = reader[0].ToString();
							profile.Name = reader[1].ToString();
							profile.Age = int.Parse(reader[2].ToString());
							profile.Hobbies = reader[3].ToString();
							profile.Gender = (Gender)Enum.Parse(typeof(Gender), reader[4].ToString());
							profile.Joined = reader[5].ToString();
						}
					}
					return profile;

				}
			}
			finally
			{
				_SqlConnection.Close();
			}
		}

		public bool UpdateProfileById(Profile profile)
		{
			try
			{
				_SqlConnection.Open();

				using (var sqlCommand = new SqlCommand("update Profile set Name='"+profile.Name+"',Age="+profile.Age+", Profile.Hobbies='"+profile.Hobbies+"',Profile.Gender='"+profile.Gender+"' where Profile.Email='"+profile.Email+"'", _SqlConnection))
				{
					var reader = sqlCommand.ExecuteNonQuery();
					if (reader>0)
					{
						return true;
					}
					else
					{
						return false;
					}

				}
			}
			finally
			{
				_SqlConnection.Close();
			}
			
		}
	}
}
