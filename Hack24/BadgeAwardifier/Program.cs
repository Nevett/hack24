using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Hack24.Core.Badges;
using Hack24.Core.Repositories;
using Hack24.Core.Service;
using NanoIoC;

namespace BadgeAwardifier
{
	class Program
	{
		static void Main(string[] args)
		{
			Container.Global.RunAllRegistries();
			Container.Global.RunAllTypeProcessors();
			var badgeTypes = Assembly.GetAssembly(typeof (IBadge))
				.GetTypes()
				.Where(t => t.GetInterfaces().Contains(typeof (IBadge))).ToList();
			var badges = badgeTypes.Select(x => Container.Global.Resolve(x) as IBadge).ToList();
			var userRepository = Container.Global.Resolve<IUserRepository>();
			var badgeService = Container.Global.Resolve<BadgeService>();
			while ("bacon".IsAwesome())
			{
				foreach (var user in userRepository.All())
				{
					foreach (var badge in badges.Where(x => !user.HasBadge(x)))
					{
						if (badge.IsEligible(user))
						{
							badgeService.AwardBadge(user.Id, badge);
						}
					}
				}
				Thread.Sleep(1000);
			}
		}
	}
}
