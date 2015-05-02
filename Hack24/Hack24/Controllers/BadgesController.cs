using System;
using System.Linq;
using System.Web.Mvc;
using Hack24.Core.Entities;
using Hack24.Core.Repositories;

namespace Hack24.Controllers
{
	public class BadgesController : Controller
	{
		private readonly IUserRepository userRepository;
		private readonly User currentUser;

		public BadgesController(IUserRepository userRepository, User currentUser)
		{
			this.userRepository = userRepository;
			this.currentUser = currentUser;
		}

		public ActionResult MyBadges()
		{
			var user = userRepository.Get(currentUser.Id);
			return this.Json(user.Badges, JsonRequestBehavior.AllowGet);
		}
	}
}