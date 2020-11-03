using CommonModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingManager.Services.Interfaces
{
	public interface IProfileService
	{

		Profile GetProfileById(string Id);
		bool UpdateProfileById(Profile profile);
	}
}
