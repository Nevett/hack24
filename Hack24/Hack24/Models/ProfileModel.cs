using System.Collections;
using System.Collections.Generic;
using Hack24.Core.Entities;

namespace Hack24.Models
{
	public class ProfileModel
	{
		public User Person { get; set; }
		public IDictionary<string, string> BadgeNames { get; set; }
	}
}