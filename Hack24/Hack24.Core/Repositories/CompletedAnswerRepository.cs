using Hack24.Core.Entities;
using Raven.Client;

namespace Hack24.Core.Repositories
{
	public sealed class CompletedAnswerRepository: RavenRepository, ICompletedAnswerRepository
	{
		public void Store(CompletedAnswer completedAnswer)
		{
			using (IDocumentSession session = this.DocStore.OpenSession())
			{
				session.Store(completedAnswer);
				session.SaveChanges();
			}
		}
	}
}