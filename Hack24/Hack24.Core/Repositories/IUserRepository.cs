using System;
using System.Collections;
using System.Collections.Generic;
using Hack24.Core.Entities;

namespace Hack24.Core.Repositories
{
	public interface IUserRepository
	{
		User Get(Guid id);
		IEnumerable<User> All();
		void Store(User user);
	}
}