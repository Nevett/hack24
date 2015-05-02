using System;
using Hack24.Core.Enums;

namespace Hack24.Core.Entities.Raven
{
	public class ManagerMetricAverage
	{
		public Guid ManagerId { get; set; }
		public Metric Metric { get; set; }
		public double Score { get; set; }
	}
}