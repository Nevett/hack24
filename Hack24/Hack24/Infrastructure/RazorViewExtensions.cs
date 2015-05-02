using System.Web.Mvc;
using Hack24.Core.Entities;
using NanoIoC;

namespace Hack24.Infrastructure
{
	public static class RazorViewExtensions
	{
		public static User User(this WebViewPage view)
		{
			return Container.Global.Resolve<Hack24.Core.Entities.User>();
		}
	}
}