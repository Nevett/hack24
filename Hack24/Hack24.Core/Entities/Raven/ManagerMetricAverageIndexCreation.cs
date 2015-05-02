﻿using System;
using System.Linq;
using Hack24.Core.Enums;
using Mono.CSharp;
using Raven.Abstractions.Indexing;
using Raven.Client.Indexes;

namespace Hack24.Core.Entities.Raven
{
	public class ManagerMetricAverageIndexCreation : AbstractIndexCreationTask<AnswerMetric, ManagerMetricAverageIndexCreation.ManagerMetricAverage>
	{
		public ManagerMetricAverageIndexCreation()
		{
			Map = answerMetrics => from m in answerMetrics
				select new
				{
					m.ManagerId,
					m.Metric,
					m.Score,
					AnswerCount =1
				};

			Reduce = results => from result in results
				group result by new {result.ManagerId, result.Metric} into g
				select new
				{
					g.Key.ManagerId,
					g.Key.Metric,
					Score = g.Sum(x => x.Score) / g.Sum(x=>x.AnswerCount),
					AnswerCount = g.Sum(x=>x.AnswerCount)
				};
		}

		public class ManagerMetricAverage
		{
			public Guid ManagerId { get; set; }
			public Metric Metric { get; set; }
			public double Score { get; set; }

			// used for calcs
			public int AnswerCount { get; set; }
		}
	}
}