using BookingManager.DataAccessLayer.Interfaces;
using BookingManager.DataAccessLayer.Services;
using BookingManager.Services.Interfaces;
using CommonModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingManager.Services.Services
{
	public class LoginService : ILoginService
	{
		public bool GetAuthentiction(Login login)
		{
			IAuthencation _DbAuth = new Authentication();
			return _DbAuth.GetAuthencation(login);
		}

		public string Signup(Login login)
		{
			IAuthencation _DbAuth = new Authentication();
			return _DbAuth.SignUP(login);
		}
	}
}
