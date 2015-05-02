using System;
using System.Collections;
using System.Collections.Generic;

namespace Hack24.Core.Entities
{
	public class User
	{
		public User()
		{
			TeamMembers = new List<User>();
		}

		public Guid Id { get; set; }
		public string EmailAddress { get; set; }
		public string Forename { get; set; }
		public string Surname { get; set; }
		public string Password { get; set; }
		public User Manager { get; set; }
		public IList<User> TeamMembers { get; set; } 
	}
}