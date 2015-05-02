using System;
using System.Linq;
using Hack24.Core.Enums;
using Mono.CSharp;
using Raven.Abstractions.Indexing;
using Raven.Client.Indexes;

namespace Hack24.Core.Entities.Raven
{
	public class ManagerTotalIndex : AbstractIndexCreationTask<AnswerMetric, ManagerTotalIndex.ManagerTotal>
	{
		public ManagerTotalIndex()
		{
			Map = answerMetrics => from m in answerMetrics
				select new
				{
					m.ManagerId,
					m.Score,
		
				};

			Reduce = results => from result in results
				group result by result.ManagerId into g
				select new
				{
					ManagerId = g.Key,
					Score = g.Sum(x => x.Score)
			
				};
		}

		public class ManagerTotal
		{
			public Guid ManagerId { get; set; }
			public double Score { get; set; }

		}
	}
}