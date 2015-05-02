using System;
using System.Linq;
using System.Web.Mvc;
using Hack24.Core.Entities;
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

			if (question == null)
				return Json(null, JsonRequestBehavior.AllowGet);

			return Json(new 
			{ 
				question.Id, 
				question.Text, 
				question.ImageUrl, 
				Answers = question.Answers.Select(a => new
					{
					a.Id,
					a.ImageUrl,
					a.Text
					})
			}, JsonRequestBehavior.AllowGet);
		}
	}
}