using System.Collections.Generic;
using Hack24.Core.Entities;

namespace Hack24.Core.Repositories
{
	public class QuestionRepository : RavenRepository, IQuestionRepository
	{

		IEnumerable<Question> All()
		{

			var data = this.DocStore.DatabaseCommands.GetDocuments(0, 20);

			return new Question[0];
		}
	}
}