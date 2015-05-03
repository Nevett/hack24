using System.Linq;
using Hack24.Core.Entities;
using Hack24.Core.Repositories;

namespace Hack24.Core.Badges
{
	public class TenAnswersBadge : IBadge
	{
		private readonly ICompletedAnswerMetricRepository completedAnswerMetricRepository;

		public TenAnswersBadge(ICompletedAnswerMetricRepository completedAnswerMetricRepository)
		{
			this.completedAnswerMetricRepository = completedAnswerMetricRepository;
		}

		public string Name { get { return "Ten answers!"; } }
		public string Description { get { return "You've hit double figures, nice job!"; } }

		public bool IsEligible(User user)
		{
			return completedAnswerMetricRepository.All().Where(a => a.UserId == user.Id).GroupBy(x => x.AnswerId).Count() >= 10;
		}
	}
}