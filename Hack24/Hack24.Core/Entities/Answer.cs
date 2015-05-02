using System;
using System.Collections.Generic;
using Hack24.Core.Enums;

namespace Hack24.Core.Entities
{
	public sealed class Answer
	{
		public readonly Guid Id;
		public readonly string Text;
		public readonly string ImageUrl;
		public IDictionary<Metric, int> MetricModifiers;
	}
}