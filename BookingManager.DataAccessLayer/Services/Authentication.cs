using BookingManager.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using CommonModels;
using System.Data.SqlClient;

namespace BookingManager.DataAccessLayer.Services
{
	public class Authentication:IAuthencation
	{
		private string _ConnectionString=null;
		private SqlConnection _SqlConnection;
		private SqlCommand _SqlCommand;
		
		public Authentication()
		{
			
			IDBConnection dBConnection = new DBConnection();
			_ConnectionString = dBConnection.GetConnectionString();
			_SqlConnection = new SqlConnection(_ConnectionString);

		}

		public bool GetAuthencation(Login login)
		{
			try
			{
				_SqlConnection.Open();
				using (_SqlCommand = new SqlCommand("Select * from Auth where Email='" + login.Email + "' and Password='" + login.Password + "'", _SqlConnection))
				{
					var reader = _SqlCommand.ExecuteReader();
					if (reader.HasRows)
					{
						return true;
					}
				}
				return false;
			}
			finally
			{
				_SqlConnection.Close();
			}
			
		}
		private bool ISValidUser(string _Email)
		{
			try
			{
				_SqlConnection.Open();
				using (_SqlCommand =new SqlCommand("select * from Auth where Email='"+_Email+"'",_SqlConnection))
				{
					var reader = _SqlCommand.ExecuteReader();
					if (reader.HasRows)
					{
						return true;
					}
				}
			}
			finally
			{
				_SqlConnection.Close();
			}
			return false;
		}
		public string SignUP(Login login)
		{
			if (this.ISValidUser(login.Email))
			{
				return "User Already Exists";
			}
			else
			{
				try
				{
					_SqlConnection.Open();
					using (_SqlCommand = new SqlCommand("Insert Into Auth values ('" + login.Email + "','" + login.Password + "')", _SqlConnection))
					{
						_SqlCommand.ExecuteNonQuery();
					}
					return "User Succesfully Created";
				}
				finally
				{
					_SqlConnection.Close();
					
				}
				
			}
		}
	}
}
