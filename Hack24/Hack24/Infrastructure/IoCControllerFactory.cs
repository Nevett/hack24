using System;
using System.Web.Mvc;
using System.Web.Routing;
using NanoIoC;

namespace Hack24.Infrastructure
{
	public class IoCControllerFactory : DefaultControllerFactory
	{
		private readonly IContainer container;

		public IoCControllerFactory(IContainer container)
		{
			this.container = container;
		}

		protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
		{
			return container.Resolve(controllerType) as Controller;
		}
	}
}