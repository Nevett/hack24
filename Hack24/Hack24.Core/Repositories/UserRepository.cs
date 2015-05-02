using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Hack24.Core.Entities;
using Hack24.Core.Helpers;
using Raven.Client;

namespace Hack24.Core.Repositories
{
	public class UserRepository : RavenRepository, IUserRepository
	{
		private static User[] hardcodedUsers;
		public UserRepository()
		{
			if (hardcodedUsers == null)
			{
				var manager1 = new User
				{
					EmailAddress = "joe@bum.com",
					Forename = "Joe",
					Surname = "Bloggs",
					Password = "123456",
					Id = GuidHelper.TestGuid("joe@bum.com"),
				};
	
				var manager2 = new User
				{
					EmailAddress = "steve@bum.com",
					Forename = "Steve",
					Surname = "Bloggs",
					Password = "123456",
					Id = GuidHelper.TestGuid("steve@bum.com"),
				};

				var subordinate1 = new User
				{
					EmailAddress = "harry@bum.com",
					Forename = "Harry",
					Surname = "Boyes",
					Password = "123456",
					Id = GuidHelper.TestGuid("harry@bum.com"),
				};
				var subordinate2 = new User
				{
					EmailAddress = "jake@bum.com",
					Forename = "Jake",
					Surname = "Turton",
					Password = "123456",
					Id = GuidHelper.TestGuid("jake@bum.com"),
				};
	
				var subordinate3 = new User
				{
					EmailAddress = "greg@bum.com",
					Forename = "Greg",
					Surname = "Tudor",
					Password = "123456",
					Id = GuidHelper.TestGuid("greg@bum.com"),
				};	

				var subordinate4 = new User
				{
					EmailAddress = "chris@bum.com",
					Forename = "Chris",
					Surname = "Nevett",
					Password = "123456",
					Id = GuidHelper.TestGuid("chris@bum.com"),
				};

				Assign(manager1, subordinate1);
				Assign(manager1, subordinate2);
				Assign(manager2, subordinate3);
				Assign(manager2, subordinate4);

				hardcodedUsers = new[]
				{
					manager1,
					manager2,
					subordinate1,
					subordinate2,
					subordinate3,
					subordinate4,
				};
			}
		}

		private static void Assign(User manager, User subordinate)
		{
			subordinate.ManagerId = manager.Id;
			manager.TeamMemberIds.Add(subordinate.Id);
		}

		public User Get(Guid id)
		{
			using (IDocumentSession session = this.DocStore.OpenSession())
			{
				return session.Load<User>(id) ?? hardcodedUsers.SingleOrDefault(x => x.Id == id);
			}
		}

		public IEnumerable<User> All()
		{
			using (IDocumentSession session = this.DocStore.OpenSession())
			{
				var dbUsers = session.Query<User>().ToList();
				dbUsers.AddRange(hardcodedUsers.Where(u => !dbUsers.Select(z => z.Id).Contains(u.Id)));
				return dbUsers;
			}
		}

		public void Store(User user)
		{
			using (IDocumentSession session = this.DocStore.OpenSession())
			{
				session.Store(user);
				session.SaveChanges();
			}
		}
	}
}