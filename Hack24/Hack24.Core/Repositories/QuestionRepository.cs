using System;
using System.Collections.Generic;
using System.Linq;
using Hack24.Core.Entities;
using Raven.Client;
using Raven.Json.Linq;

namespace Hack24.Core.Repositories
{
	public class QuestionRepository : RavenRepository, IQuestionRepository
	{
	
		public IEnumerable<Question> All()
		{
			using (IDocumentSession session = this.DocStore.OpenSession())
			{
				return session.Query<Question>().ToList();
			}
		}

		public IEnumerable<Question> ForQuiz()
		{
		 return this.All().OrderBy(x => Guid.NewGuid()).Take(5);	
		}

		public void Store(Question question)
		{
			using (IDocumentSession session = this.DocStore.OpenSession())
			{
				session.Store(question);
				session.SaveChanges();
			}
		}
	}
}