using System.Web.Mvc;
using System.Web.UI.WebControls;
using Hack24.Models;

namespace Hack24.Controllers
{
	public class ReportsController: Controller
	{
		
		public ActionResult Leaderboard()
		{
			var resource = new LeaderBoardModel
			{

			};

			return View(resource);
		}
	}
}