using System.Linq;
using Hack24.Core.Entities;
using Hack24.Core.Enums;
using Hack24.Core.Repositories;

namespace Hack24.Core.Badges
{
	public class ProblemSolverBadge : IBadge
	{
		private readonly ICompletedAnswerMetricRepository completedAnswerMetricRepository;

		public ProblemSolverBadge(ICompletedAnswerMetricRepository completedAnswerMetricRepository)
		{
			this.completedAnswerMetricRepository = completedAnswerMetricRepository;
		}

		public string Name { get { return "Problem Solver!"; } }
		public string Description { get { return "Achieved a high \"Problem Solving\" score from your team"; } }
		public bool IsEligible(User user)
		{
			return
				completedAnswerMetricRepository.GetMetricTotals(user.Id)
					.Where(x => x.Metric == Metric.ProblemSolving)
					.Sum(x => x.Score) > 50;
		}
	}
}