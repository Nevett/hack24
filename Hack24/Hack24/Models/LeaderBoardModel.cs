using System.Collections.Generic;
using Hack24.Core.Entities;

namespace Hack24.Models
{
	public class LeaderBoardModel
	{
		public IEnumerable<ScoreBoardRow> Leaderboard { get; set; }
	}
}