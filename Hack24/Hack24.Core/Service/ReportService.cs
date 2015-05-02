using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Hack24.Core.Entities;
using Hack24.Core.Repositories;

namespace Hack24.Core.Service
{
	public class ReportService : IReportService
	{
		private readonly ICompletedAnswerMetricRepository answerMetricRepository;
		private readonly IUserRepository userRepository;

		public ReportService(ICompletedAnswerMetricRepository answerMetricRepository, IUserRepository userRepository)
		{
			this.answerMetricRepository = answerMetricRepository;
			this.userRepository = userRepository;
		}

		public IEnumerable<ScoreBoardRow> Leaderboard()
		{
			var totalScores = this.answerMetricRepository.GetLeaderboard();
			var managers = this.userRepository.All().Where(x => x.TeamMemberIds.Any());

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

		public UserProfileReport ManagerReport(Guid userId)
		{
			var user = this.userRepository.Get(userId);
			var metricAverage = this.answerMetricRepository.GetMetricAverages(userId);

			var totalScore = this.answerMetricRepository.GetTotal(userId);

			return new UserProfileReport
			{
				User = user,
				TotalScore = totalScore,
				Metrics = metricAverage,
			};

		}
	}
}