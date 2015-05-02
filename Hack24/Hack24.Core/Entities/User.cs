using System;
using System.Collections;
using System.Collections.Generic;
using Hack24.Core.Badges;

namespace Hack24.Core.Entities
{
	public class User
	{
		public User()
		{
			TeamMemberIds = new List<Guid>();
			Badges = new List<string>();
		}

		public Guid Id { get; set; }
		public string EmailAddress { get; set; }
		public string Forename { get; set; }
		public string Surname { get; set; }
		public string Password { get; set; }
		public Guid ManagerId { get; set; }
		public IList<Guid> TeamMemberIds { get; set; }
		public IList<string> Badges { get; set; }

		public bool HasBadge(IBadge badge)
		{
			return this.Badges.Contains(badge.GetType().FullName);
		}
	}
}