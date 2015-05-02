using System.Collections.Generic;
using Hack24.Core.Entities;

namespace Hack24.Core.Service
{
	public interface IReportService
	{
		IEnumerable<ScoreBoardRow> Leaderboard();
	}
}