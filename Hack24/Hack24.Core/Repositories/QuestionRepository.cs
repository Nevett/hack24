using System;
using System.Collections.Generic;
using System.Linq;
using Hack24.Core.Entities;
using Raven.Client;

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

		public Question GetForUser(Guid userId)
		{
			using (IDocumentSession session = this.DocStore.OpenSession())
			{
				var questionIds = session.Query<Question>().ToList().Select(x => x.Id);
				var answeredIds =
					session.Query<AnswerMetric>().ToList()
						.GroupBy(x => x.QuestionId)
						.Where(x => x.Any(z => z.UserId == userId))
						.Select(x => x.Key);

				var unansweredIds = questionIds.Except(answeredIds).ToList();

				if (!unansweredIds.Any())
					return null;

				var rand = new Random();
				var id = unansweredIds.ElementAt(rand.Next(0, unansweredIds.Count() - 1));

				return session.Load<Question>(id);
			}
		}

		public Question Get(Guid questionId)
		{
			using (IDocumentSession session = this.DocStore.OpenSession())
			{
				return session.Load<Question>(questionId);
			}
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