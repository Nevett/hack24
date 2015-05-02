using System;
using NanoIoC;
namespace Hack24.Core
{
	public class DefaultTypeProcessor : ITypeProcessor
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