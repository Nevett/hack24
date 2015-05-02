using Hack24.Core.Entities;
using Raven.Client;

namespace Hack24.Core.Repositories
{
	public sealed class CompletedAnswerMetricRepository: RavenRepository, ICompletedAnswerMetricRepository
	{
		public void Store(AnswerMetric metric)
		{
			using (IDocumentSession session = this.DocStore.OpenSession())
			{
				session.Store(metric);
				session.SaveChanges();
			}
		}
	}
}