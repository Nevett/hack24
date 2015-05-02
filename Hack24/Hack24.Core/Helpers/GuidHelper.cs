using System;
using System.Security.Cryptography;
using System.Text;

namespace Hack24.Core.Helpers
{
	public static class GuidHelper
	{
		public static Guid TestGuid(string thing, int? number = null)
		{
			if (number.HasValue)
				thing += number;
			var bytes = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(thing));
			return new Guid(bytes);
		}
	}
}