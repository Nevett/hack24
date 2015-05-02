using System;
using Hack24.Core.Enums;

namespace Hack24.Core.Entities
{
	public sealed class AnswerMetric
	{
		public Guid Id { get; set; }
		public Guid QuestionId { get; set; }
		public Guid AnswerId { get; set; }
		public Guid ManagerId { get; set; }
		public Guid UserId { get; set; }
		public Metric Metric { get; set; }
		public int Score { get; set; }
	}
}