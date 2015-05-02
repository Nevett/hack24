using System;
using Hack24.Core.Badges;
using Hack24.Core.Entities;
using Hack24.Core.Repositories;

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
	}
}