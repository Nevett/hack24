using System;
using System.Collections.Generic;
using Hack24.Core.Entities;
using Hack24.Core.Entities.Raven;

namespace Hack24.Core.Repositories
{
	public interface ICompletedAnswerMetricRepository
	{
		void Store(AnswerMetric metric);
		List<ManagerMetricAverageIndex.ManagerMetricAverage> GetMetricAverages(Guid userId);
		List<ManagerTotalIndex.ManagerTotal> GetTotal(Guid userId);
		List<ManagerTotalIndex.ManagerTotal> GetLeaderboard();
	}
}