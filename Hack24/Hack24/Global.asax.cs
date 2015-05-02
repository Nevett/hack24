using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using Hack24.Core;
using Hack24.Core.Entities;
using Hack24.Core.Entities.Raven;
using Hack24.Core.Repositories;
using Hack24.Infrastructure;
using NanoIoC;

namespace Hack24
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();

			WebApiConfig.Register(GlobalConfiguration.Configuration);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);

			//Container.Global.RunAllRegistries();
			Container.Global.RunAllTypeProcessors();
			ControllerBuilder.Current.SetControllerFactory(Container.Global.Resolve<IoCControllerFactory>());

			new RavenBootStrap().Setup();
		}
	}

	internal sealed class DefaultTypeProcessor : ITypeProcessor
	{
		public void Process(Type type, IContainer container)
		{
			if (!type.IsClass || type.IsAbstract || !type.Assembly.FullName.StartsWith("Hack24."))
				return;

			var interfaces = type.GetInterfaces();

			foreach (var face in interfaces)
			{
				if (face.Name == "I" + type.Name)
					container.Register(face, type, Lifecycle.Singleton);
			}
		}
	}
}