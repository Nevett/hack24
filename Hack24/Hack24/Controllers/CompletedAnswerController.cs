using System;
using System.Net;
using System.Web.Mvc;
using Hack24.Core.Entities;
using Hack24.Core.Service;

namespace Hack24.Controllers
{
	public sealed class CompletedAnswerController
	{
		private readonly ICompletedAnswerService _completedAnswerService;

		public CompletedAnswerController(ICompletedAnswerService completedAnswerService)
		{
			_completedAnswerService = completedAnswerService;
		}

		[System.Web.Http.HttpPost]
		public ActionResult Answer(Guid questionId, Guid answerId, User currentUser)
		{
			this._completedAnswerService.RecordAnswer(questionId, answerId, currentUser);


			return new HttpStatusCodeResult(HttpStatusCode.OK);
		}
	}
}