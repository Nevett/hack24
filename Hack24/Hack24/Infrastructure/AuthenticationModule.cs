using System;
using System.Web;
using System.Web.Security;
using Hack24.Core.Entities;
using Hack24.Core.Repositories;
using NanoIoC;

namespace Hack24.Infrastructure
{
	public class AuthenticationModule : IHttpModule
	{
		public void Init(HttpApplication context)
		{
			context.BeginRequest += AuthRequest;
		}

		private void AuthRequest(object sender, EventArgs eventArgs)
		{
			var application = sender as HttpApplication;
			if (application == null)
				return;

			var authCookie = application.Request.Cookies[FormsAuthentication.FormsCookieName];
			if (authCookie != null)
			{
				var ticket = FormsAuthentication.Decrypt(authCookie.Value);
				Container.Global.Inject(Container.Global.Resolve<IUserRepository>().Get(new Guid(ticket.Name)), Lifecycle.HttpContextOrThreadLocal);
				return;
			}
			Container.Global.Inject<User>(null, Lifecycle.HttpContextOrThreadLocal);
		}

		public void Dispose()
		{
		}
	}
}