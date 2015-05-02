using System.Collections.Generic;
using Hack24.Core.Entities;

namespace Hack24.Core.Repositories
{
	public class QuestionRepository : IQuestionRepository
	{

		IEnumerable<Question> All()
		{
			return new Question[0];
		}
	}
}