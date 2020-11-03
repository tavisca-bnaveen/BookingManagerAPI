using System;

namespace CommonModels
{
	public class Profile
	{
		public string Email { get; set; }
		public string  Name { get; set; }

		public int Age { get; set; }
		public string Joined { get; set; }

		public string Hobbies { get; set; }

		public Gender Gender { get; set; }
	}
}
