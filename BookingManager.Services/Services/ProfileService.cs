using BookingManager.DataAccessLayer.Interfaces;
using BookingManager.DataAccessLayer.Services;
using BookingManager.Services.Interfaces;
using CommonModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingManager.Services.Services
{
	public class ProfileService : IProfileService
	{
		IProfile dbProfileService;
		public ProfileService()
		{
			dbProfileService = new DbProfileService();
		}

		public bool CreateProfile(Profile profile)
		{
			return dbProfileService.CreateProfile(profile);
		}

		public Profile GetProfileById(string Id)
		{
			return dbProfileService.GetProfileById(Id);
		}

		public bool UpdateProfileById(Profile profile)
		{
			return dbProfileService.UpdateProfileById(profile);
		}
	}
}
