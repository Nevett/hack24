using System.Web.Mvc;

namespace Hack24.Controllers
{
	public class HomeController: Controller
	{
		public ViewResult Index()
		{
			return View();
		}
	}
}