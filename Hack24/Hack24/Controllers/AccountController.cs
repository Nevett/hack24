using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hack24.Core.Repositories;
using Hack24.Models;

namespace Hack24.Controllers
{
    public class AccountController : Controller
    {
	    private readonly IUserRepository userRepository;

	    public AccountController(IUserRepository userRepository)
	    {
		    this.userRepository = userRepository;
	    }

	    public ActionResult Login()
	    {
		    return View(new LoginModel());
	    }

		[HttpPost]
	    public ActionResult Login(LoginModel model)
		{
			var user = userRepository.All().SingleOrDefault(u => u.EmailAddress == model.EmailAddress);
			if (user != null)
			{
				if (user.Password == model.Password)
				{
					//success
				}
			}
			return View();
		}
    }
}
