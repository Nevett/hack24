using System;
using System.Collections.Generic;
using Hack24.Core.Entities;
using Hack24.Core.Entities.Raven;

namespace Hack24.Core.Repositories
{
	public interface ICompletedAnswerMetricRepository
	{
		void Store(AnswerMetric metric);
		IEnumerable<ManagerMetricAverageIndex.ManagerMetricAverage> GetMetricAverages(Guid userId);
		IEnumerable<ManagerTotalIndex.ManagerTotal> GetTotal(Guid userId);
		IEnumerable<ManagerTotalIndex.ManagerTotal> GetLeaderboard();
		IEnumerable<AnswerMetric> All();
	}
}