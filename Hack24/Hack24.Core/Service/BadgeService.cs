using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Hack24.Core.Badges;
using Hack24.Core.Entities;
using Hack24.Core.Repositories;
using NanoIoC;

namespace Hack24.Core.Service
{
	public class BadgeService
	{
		private readonly IUserRepository userRepository;

		public BadgeService(IUserRepository userRepository)
		{
			this.userRepository = userRepository;
		}

		public void AwardBadge(Guid userId, IBadge badge)
		{
			var user = userRepository.Get(userId);
			user.Badges.Add(badge.GetType().FullName);
			userRepository.Store(user);
		}

		public IEnumerable<IBadge> All()
		{
			var badgeTypes = Assembly.GetAssembly(typeof(IBadge))
	.GetTypes()
	.Where(t => t.GetInterfaces().Contains(typeof(IBadge))).ToList();
			return  badgeTypes.Select(x => Container.Global.Resolve(x) as IBadge).ToList();
		}
	}
}