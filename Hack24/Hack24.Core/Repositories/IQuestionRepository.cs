using System;
using System.Collections.Generic;
using Hack24.Core.Entities;

namespace Hack24.Core.Repositories
{
	public interface IQuestionRepository
	{
		IEnumerable<Question> All();
		void Store(Question question);
		IEnumerable<Question> ForQuiz();
		Question Get(Guid questionId);
	}
}