using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Hack24.Core.Entities;
using Hack24.Core.Repositories;
using Hack24.Core.Service;
using Hack24.Models;

namespace Hack24.Controllers
{
    public class AccountController : Controller
    {
	    private readonly IUserRepository userRepository;
	    private readonly IReportService reportService;

	    public AccountController(IUserRepository userRepository, IReportService reportService)
	    private readonly BadgeService badgeService;
	    private readonly User currentUser;

	    public AccountController(IUserRepository userRepository, BadgeService badgeService, User currentUser)
	    {
		    this.userRepository = userRepository;
		    this.reportService = reportService;
		    this.badgeService = badgeService;
		    this.currentUser = currentUser;
	    }

	    public ActionResult Login()
	    {
		    return View(new LoginModel());
	    }

		[HttpPost]
	    public ActionResult Login(LoginModel model, string redirectUrl)
		{
			var user = userRepository.All().SingleOrDefault(u => u.EmailAddress == model.EmailAddress);
			if (user != null)
			{
				if (user.Password == model.Password)
				{
					FormsAuthentication.SetAuthCookie(user.Id.ToString(), true);
					return Redirect(redirectUrl ?? "/");
				}
			}
			return View();
		}

		public ActionResult LogOut()
		{
			FormsAuthentication.SetAuthCookie(string.Empty, true);
			return Redirect("/");
		}

	    public ActionResult Profile(Guid id)
	    {
		    var report = this.reportService.ManagerReport(id);
	    var report = this.reportService.ManagerReport(id);
		    {
			    BadgeNames = badgeService.All().ToDictionary(x => x.GetType().FullName, x => x.Name),
			    Person = currentUser
		    });
	    }
    }
}
