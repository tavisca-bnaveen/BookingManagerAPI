
using CommonModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingManager.DataAccessLayer.Interfaces
{
	public interface IAuthencation
	{
		bool GetAuthencation(Login login);
		string SignUP(Login login);
	}
}
