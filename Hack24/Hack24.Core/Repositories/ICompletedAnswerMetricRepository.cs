﻿using System.Collections.Generic;
using Hack24.Core.Entities;

namespace Hack24.Core.Repositories
{
	public interface ICompletedAnswerMetricRepository
	{
		void Store(AnswerMetric metric);
		IEnumerable<AnswerMetric> All();
	}
}