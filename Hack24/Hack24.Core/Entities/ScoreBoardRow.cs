using System;

namespace Hack24.Core.Entities
{
	public sealed class ScoreBoardRow
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public double Score { get; set; }
	}
}