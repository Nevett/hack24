using System;
using System.Collections.Generic;
using Hack24.Core.Enums;

namespace Hack24.Core.Entities
{
	public class CompletedAnswer
	{
		public Guid ManagerId { get; set; }
		public Guid UserId { get; set; }
		public Guid QuestionId { get; set; }
		public Guid AnswerId { get; set; }
		public IDictionary<Metric, int> MetricModifiers { get; set; }

		public CompletedAnswer()
		{
		 this.MetricModifiers = new Dictionary<Metric, int>();
		}
	}
}