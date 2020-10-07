using CommonModels;
using System;
using System.Collections.Generic;
using System.Text;


namespace BookingManager.Services.Interfaces
{
	public interface ILoginService
	{
		bool GetAuthentiction(Login login);
		string Signup(Login login);
	}
}
