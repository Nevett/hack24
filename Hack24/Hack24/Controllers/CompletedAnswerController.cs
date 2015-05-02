using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Hack24.Core.Entities;
using Hack24.Core.Repositories;

namespace Hack24.Controllers
{
	public sealed class CompletedAnswerController
	{
		private readonly ICompletedAnswerRepository _answerRepository;
		private readonly IQuestionRepository _questionRepository;

		public CompletedAnswerController(ICompletedAnswerRepository answerRepository, IQuestionRepository questionRepository)
		{
			_answerRepository = answerRepository;
			_questionRepository = questionRepository;
		}

		[System.Web.Http.HttpPost]
		public ActionResult Answer(Guid questionId, Guid answerId, User currentUser)
		{
			var question = this._questionRepository.Get(questionId);
			var answer = question.Answers.First(x => x.Id == answerId);

			// we might want to store each metric update as its own result. not sure yet

			_answerRepository.Store(new CompletedAnswer
			{
				ManagerId = currentUser.Manager.Id,
				UserId = currentUser.Id,
				QuestionId = questionId,
				AnswerId = answerId,
				MetricModifiers = answer.MetricModifiers
			});

			return new HttpStatusCodeResult(HttpStatusCode.OK);
		}
	}
}