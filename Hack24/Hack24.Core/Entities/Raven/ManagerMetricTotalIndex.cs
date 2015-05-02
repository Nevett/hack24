using System;
using System.Linq;
using Hack24.Core.Enums;
using Raven.Client.Indexes;

namespace Hack24.Core.Entities.Raven
{
	public class ManagerMetricTotalIndex : AbstractIndexCreationTask<AnswerMetric, ManagerMetricTotalIndex.ManagerMetricTotal>
	{
		public ManagerMetricTotalIndex()
		{
			Map = answerMetrics => from m in answerMetrics
			let manager = LoadDocument<User>(m.ManagerId.ToString()) 
				select new
				{
					m.ManagerId,
					m.Metric,
					m.Score,
					manager.Forename,
					manager.Surname
		
				};

			Reduce = results => from result in results
				group result by new {result.ManagerId, result.Metric, result.Forename, result.Surname} into g
				select new
				{
					g.Key.ManagerId,
					g.Key.Metric,
					g.Key.Forename,
					g.Key.Surname,
					Score = g.Sum(x => x.Score)
			
				};
		}

		public class ManagerMetricTotal
		{
			public Guid ManagerId { get; set; }

			public Metric Metric { get; set; }
			public double Score { get; set; }
			public string Forename { get; set; }
			public string Surname { get; set; }

		}
	}
}