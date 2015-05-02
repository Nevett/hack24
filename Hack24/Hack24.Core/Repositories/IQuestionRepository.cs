using System.Collections.Generic;
using Hack24.Core.Entities;

namespace Hack24.Core.Repositories
{
	public interface IQuestionRepository
	{
		IEnumerable<Question> All();
		void Store(Question question);
		IEnumerable<Question> All();
		IEnumerable<Question> ForQuiz();
		void Store(Question question);
	}
}