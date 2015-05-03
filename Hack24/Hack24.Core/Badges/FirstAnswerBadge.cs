using System.Linq;
using Hack24.Core.Entities;
using Hack24.Core.Repositories;

namespace Hack24.Core.Badges
{
	public class FirstAnswerBadge : IBadge
	{
		private readonly ICompletedAnswerMetricRepository completedAnswerMetricRepository;

		public FirstAnswerBadge(ICompletedAnswerMetricRepository completedAnswerMetricRepository)
		{
			this.completedAnswerMetricRepository = completedAnswerMetricRepository;
		}

		public string Name { get { return "First answer!"; } }
		public string Description { get { return "Answered your first question. Keep going!"; } }

		public bool IsEligible(User user)
		{
			return completedAnswerMetricRepository.All().Where(a => a.UserId == user.Id).GroupBy(x => x.AnswerId).Any();
		}
	}
}