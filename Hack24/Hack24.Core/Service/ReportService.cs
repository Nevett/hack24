using System;
using System.Collections.Generic;
using System.Linq;
using Hack24.Core.Entities;
using Hack24.Core.Repositories;

namespace Hack24.Core.Service
{
	public class ReportService : IReportService
	{
		private readonly ICompletedAnswerMetricRepository _answerMetricRepository;
		private readonly IUserRepository _userRepository;

		public ReportService(ICompletedAnswerMetricRepository answerMetricRepository, IUserRepository userRepository)
		{
			_answerMetricRepository = answerMetricRepository;
			_userRepository = userRepository;
		}

		public IEnumerable<ScoreBoardRow> Leaderboard()
		{
			var totalScores = this._answerMetricRepository.GetLeaderboard();
			var managers = this._userRepository.All().Where(x => x.TeamMembers.Any());

			var scoreboard = new List<ScoreBoardRow>();

			foreach (var score in totalScores)
			{
				var user = managers.First(x => x.Id == score.ManagerId);
				scoreboard.Add(new ScoreBoardRow
				{
					Id = user.Id,
					Name = user.Forename + " " + user.Surname,
					Score = score.Score

				});
			}

			return scoreboard;
		}
		public void ManagerReport(Guid userId)
		{
			var metricAverage = this._answerMetricRepository.GetMetricAverages(userId);

			var totalScore = this._answerMetricRepository.GetTotal(userId);

		}
	}
}