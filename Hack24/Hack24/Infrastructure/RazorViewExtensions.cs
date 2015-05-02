using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hack24.Core.Entities;
using Hack24.Core.Service;
using NanoIoC;
using Newtonsoft.Json;

namespace Hack24.Infrastructure
{
	public static class RazorViewExtensions
	{
		public static User User(this WebViewPage view)
		{
			return Container.Global.Resolve<Hack24.Core.Entities.User>();
		}

		public static IHtmlString Badges(this HtmlHelper html)
		{
			var badges = Container.Global.Resolve<BadgeService>().All();
			var str = "<script type='text/javascript'>window.badgeTitles=";
			str += JsonConvert.SerializeObject(badges.ToDictionary(x => x.GetType().FullName, x => x.Name));
			str += "</script>";
			return new HtmlString(str);
		}
	}
}