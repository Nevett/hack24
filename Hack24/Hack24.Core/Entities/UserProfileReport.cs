using System.Collections.Generic;
using Hack24.Core.Entities.Raven;

namespace Hack24.Core.Entities
{
	public sealed class UserProfileReport
	{
		public IEnumerable<ManagerTotalIndex.ManagerTotal> TotalScore { get; set; }
		public IEnumerable<ManagerMetricAverageIndex.ManagerMetricAverage> Metrics { get; set; }
		public User User { get; set; }
	}
}