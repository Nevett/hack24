using System;
using System.Collections.Generic;
using Hack24.Core.Entities;

namespace Hack24.Core.Repositories
{
	public interface IQuestionRepository
	{
		IEnumerable<Question> All();
		void Store(Question question);
		Question Get(Guid questionId);
		Question GetForUser(Guid userId);
	}
}