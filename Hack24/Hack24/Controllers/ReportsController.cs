using System.Web.Mvc;

namespace Hack24.Controllers
{
    public class ReportsController : Controller
    {
        //
        // GET: /Reports/

        public ActionResult Leaderboard()
        {
            return this.View();
        }

    }
}
