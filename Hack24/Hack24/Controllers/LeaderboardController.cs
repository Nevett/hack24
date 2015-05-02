using System.Web.Mvc;
using Hack24.Core.Service;
using Hack24.Models;

namespace Hack24.Controllers
{
    public class LeaderboardController : Controller
    {
	    private readonly IReportService _reportService;

	    public LeaderboardController(IReportService reportService)
	    {
		    _reportService = reportService;
	    }

//
        // GET: /Reports/

        public ActionResult Index()
        {
	        var leaderboard = _reportService.Leaderboard();

	        var model = new LeaderBoardModel
	        {
				Leaderboard = leaderboard	
	        };

            return this.View(model);
        }

    }
}
