using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hack24.Models;

namespace Hack24.Controllers
{
    public class AccountController : Controller
    {
	    public ActionResult Login()
	    {
		    return View(new LoginModel());
	    }

		[HttpPost]
	    public ActionResult Login(LoginModel model)
		{
			return View();
		}
    }
}
