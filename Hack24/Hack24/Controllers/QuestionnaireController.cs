using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Optimization;
using Hack24.Core.Entities;
using Hack24.Core.Enums;

namespace Hack24.Controllers
{
	public class QuestionnaireController: Controller
	{
		public ViewResult Questionnaire()
		{
			var questions = new List<Question>
			{
				new Question
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
							ImageUrl = "http://upload.wikimedia.org/wikipedia/en/6/6d/WillowRosenberg.jpg",
							MetricModifiers = new Dictionary<Metric, int>
							{
								{Metric.Influcence, 0},
								{Metric.Leadership, 3}
							}
						},
						new Answer
						{
							Text = "Giles",
							ImageUrl = "http://vignette1.wikia.nocookie.net/buffy/images/a/a5/Buffy_-_Im_Bann_de_D%C3%A4monen_(7).jpg/revision/latest?cb=20110703171655&path-prefix=de",
							MetricModifiers = new Dictionary<Metric, int>
							{
								{Metric.Influcence, 2},
								{Metric.Leadership, 4}
							}
						},
						new Answer
						{
							Text = "Spike",
							ImageUrl = "http://upload.wikimedia.org/wikipedia/en/0/00/S203_Spike.jpg",
							MetricModifiers = new Dictionary<Metric, int>
							{
								{Metric.Influcence, 4},
								{Metric.Leadership, 2}
							}
						}
					}
				},
				new Question
				{
					Text = "Which isn't buffy character is the coolest",
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
							ImageUrl = "http://upload.wikimedia.org/wikipedia/en/6/6d/WillowRosenberg.jpg",
							MetricModifiers = new Dictionary<Metric, int>
							{
								{Metric.Influcence, 0},
								{Metric.Leadership, 3}
							}
						},
						new Answer
						{
							Text = "Giles",
							ImageUrl = "http://vignette1.wikia.nocookie.net/buffy/images/a/a5/Buffy_-_Im_Bann_de_D%C3%A4monen_(7).jpg/revision/latest?cb=20110703171655&path-prefix=de",
							MetricModifiers = new Dictionary<Metric, int>
							{
								{Metric.Influcence, 2},
								{Metric.Leadership, 4}
							}
						},
						new Answer
						{
							Text = "Spike",
							ImageUrl = "http://upload.wikimedia.org/wikipedia/en/0/00/S203_Spike.jpg",
							MetricModifiers = new Dictionary<Metric, int>
							{
								{Metric.Influcence, 4},
								{Metric.Leadership, 2}
							}
						}
					}
				}
			};

			return this.View(questions);
		}

		public ViewResult Question()
		{
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
						ImageUrl = "http://upload.wikimedia.org/wikipedia/en/6/6d/WillowRosenberg.jpg",
						MetricModifiers = new Dictionary<Metric, int>
						{
							{Metric.Influcence, 0},
							{Metric.Leadership, 3}
						}
					},
					new Answer
					{
						Text = "Giles",
						ImageUrl = "http://vignette1.wikia.nocookie.net/buffy/images/a/a5/Buffy_-_Im_Bann_de_D%C3%A4monen_(7).jpg/revision/latest?cb=20110703171655&path-prefix=de",
						MetricModifiers = new Dictionary<Metric, int>
						{
							{Metric.Influcence, 2},
							{Metric.Leadership, 4}
						}
					},
					new Answer
					{
						Text = "Spike",
						ImageUrl = "http://upload.wikimedia.org/wikipedia/en/0/00/S203_Spike.jpg",
						MetricModifiers = new Dictionary<Metric, int>
						{
							{Metric.Influcence, 4},
							{Metric.Leadership, 2}
						}
					}
				}
			};

			return View(question);
		}
	}
}