using System;
using System.Collections.Generic;
using System.Linq;
using Hack24.Core.Entities;
using Hack24.Core.Entities.Raven;
using Raven.Client;
using Raven.Client.Linq;

namespace Hack24.Core.Repositories
{
	public sealed class CompletedAnswerMetricRepository : RavenRepository, ICompletedAnswerMetricRepository
	{
		public void Store(AnswerMetric metric)
		{
			using (IDocumentSession session = this.DocStore.OpenSession())
			{
				session.Store(metric);
				session.SaveChanges();
			}
		}

		public List<ManagerMetricAverageIndex.ManagerMetricAverage> GetMetricAverages(Guid userId)
		{
			using (IDocumentSession session = this.DocStore.OpenSession())
			{
				return session.Query<ManagerMetricAverageIndex.ManagerMetricAverage>()
					.Where(x => x.ManagerId == userId)
					.ToList();
			}
		}

		public List<ManagerTotalIndex.ManagerTotal> GetTotal(Guid userId)
		{
			using (IDocumentSession session = this.DocStore.OpenSession())
			{
				return session.Query<ManagerTotalIndex.ManagerTotal>()
					.Where(x => x.ManagerId == userId)
					.ToList();
			}
		}

		public List<ManagerTotalIndex.ManagerTotal> GetLeaderboard()
		{
			using (IDocumentSession session = this.DocStore.OpenSession())
			{
				return session.Query<ManagerTotalIndex.ManagerTotal>()
					.OrderByDescending(x=>x.Score)
					.ToList();


			}
		}
	}
}