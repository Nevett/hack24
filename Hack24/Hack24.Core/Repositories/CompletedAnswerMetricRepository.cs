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

		public IEnumerable<ManagerMetricAverageIndex.ManagerMetricAverage> GetMetricAverages(Guid userId)
		{
			using (IDocumentSession session = this.DocStore.OpenSession())
			{
				return session.Query<ManagerMetricAverageIndex.ManagerMetricAverage>("ManagerMetricAverageIndex")
					.Where(x => x.ManagerId == userId)
					.ToList(); ;
			}
		}
		public IEnumerable<ManagerMetricTotalIndex.ManagerMetricTotal> GetMetricTotals(Guid userId)
		{
			using (IDocumentSession session = this.DocStore.OpenSession())
			{
				return session.Query<ManagerMetricTotalIndex.ManagerMetricTotal>("ManagerMetricTotalIndex")
					.Where(x => x.ManagerId == userId)
					.ToList(); ;
			}
		}
		public IEnumerable<ManagerTotalIndex.ManagerTotal> GetTotal(Guid userId)
		{
			using (IDocumentSession session = this.DocStore.OpenSession())
			{
				return session.Query<ManagerTotalIndex.ManagerTotal>("ManagerTotalIndex")
					.Where(x => x.ManagerId == userId)
					.ToList();
			}
		}

		public IEnumerable<ManagerTotalIndex.ManagerTotal> GetLeaderboard()
		{
			using (IDocumentSession session = this.DocStore.OpenSession())
			{
				return session.Query<ManagerTotalIndex.ManagerTotal>("ManagerTotalIndex")
					.OrderByDescending(x => x.Score)
					.ToList();
			}
		}

		public IEnumerable<AnswerMetric> All()
		{
			using (IDocumentSession session = this.DocStore.OpenSession())
			{
				return session.Query<AnswerMetric>().ToList();
			}
		}
	}
}