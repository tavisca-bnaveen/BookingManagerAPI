using CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingManager.Models
{
	public class IntermediateLogin
	{
		public Login Login { get; set; }
		public string NewPassword { get; set; }
	}
}
