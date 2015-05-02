using System.Collections.Generic;
using System.Web.Mvc;
using Hack24.Core.Entities;
using Hack24.Core.Enums;
using Hack24.Core.Repositories;

namespace Hack24.Controllers
{
	public class QuestionnaireController: Controller
	{
		private readonly IQuestionRepository _questionRepository;

		public QuestionnaireController(IQuestionRepository questionRepository)
		{
			_questionRepository = questionRepository;
		}

		public ViewResult Question()
		{
			//var questions = this._questionRepository.ForQuiz();


			var question = new Question
			{
				Text = "Which buffy character is the coolest",
				ImageUrl = "http://www.thetvcritic.org/assets/Buffy/_resampled/resizedimage600298-Standard-Image-Size-Buffy.jpg",
				Answers = new List<Answer>
				{
					new Answer
					{
						Text = "Zander",
						ImageUrl = "http://upload.wikimedia.org/wikipedia/en/0/0f/S721_Xander.png",
						MetricModifiers = new Dictionary<Metric, int>
						{
							{Metric.Influcence, 5},
							{Metric.Leadership, 2}
						}
					},
					new Answer
					{
						Text = "Willow",
						ImageUrl = "http://upload.wikimedia.org/wikipedia/en/0/0f/S721_Xander.png",
						MetricModifiers = new Dictionary<Metric, int>
						{
							{Metric.Influcence, 0},
							{Metric.Leadership, 3}
						}
					},
					new Answer
					{
						Text = "Giles",
						ImageUrl = "http://upload.wikimedia.org/wikipedia/en/0/0f/S721_Xander.png",
						MetricModifiers = new Dictionary<Metric, int>
						{
							{Metric.Influcence, 2},
							{Metric.Leadership, 4}
						}
					},
					new Answer
					{
						Text = "Spike",
						ImageUrl = "http://upload.wikimedia.org/wikipedia/en/0/0f/S721_Xander.png",
						MetricModifiers = new Dictionary<Metric, int>
						{
							{Metric.Influcence, 4},
							{Metric.Leadership, 2}
						}
					}
				}
			};

			return View();
		}
	}
}