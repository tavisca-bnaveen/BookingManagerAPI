using CommonModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingManager.DataAccessLayer.Interfaces
{
	public interface IProfile
	{
		Profile GetProfileById(string Id);

		bool UpdateProfileById(Profile profile);

		bool CreateProfile(Profile profile);
	}
}
