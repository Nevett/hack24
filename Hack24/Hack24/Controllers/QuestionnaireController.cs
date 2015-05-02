using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Hack24.Core.Entities;
using Hack24.Core.Enums;
using Hack24.Core.Repositories;
using Hack24.Core.Service;

namespace Hack24.Controllers
{
	public class QuestionnaireController: Controller
	{
		private readonly IQuestionRepository _questionRepository;
		private readonly User currentUser;
		private readonly ICompletedAnswerService completedAnswerService;

		public QuestionnaireController(IQuestionRepository questionRepository, User currentUser, ICompletedAnswerService completedAnswerService)
		{
			_questionRepository = questionRepository;
			this.currentUser = currentUser;
			this.completedAnswerService = completedAnswerService;
		}

		public ActionResult Index()
		{
			return this.View();
		}

		public ActionResult Question(Guid? lastQuestionId, Guid? lastAnswerId)
		{
			if (lastAnswerId.HasValue && lastAnswerId.HasValue)
				completedAnswerService.RecordAnswer(lastQuestionId.Value, lastAnswerId.Value, currentUser);

			var question = _questionRepository.GetForUser(currentUser.Id);
			return Json(question, JsonRequestBehavior.AllowGet);
		}
	}
}