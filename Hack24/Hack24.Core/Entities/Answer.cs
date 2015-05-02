using System;
using System.Collections.Generic;
using Hack24.Core.Enums;
using Raven.Imports.Newtonsoft.Json;

namespace Hack24.Core.Entities
{
	public sealed class Answer
	{
		public Guid Id { get; set; }
		public string Text { get; set; }
		public string ImageUrl { get; set; }

		[JsonIgnore]
		public IDictionary<Metric, int> MetricModifiers { get; set; }
	}
}