using Hack24.Core.Entities;

namespace Hack24.Core.Repositories
{
	public interface ICompletedAnswerRepository
	{
		void Store(CompletedAnswer completedAnswer);
	}
}