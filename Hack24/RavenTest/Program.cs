using System;
using System.Collections.Generic;
using System.Linq;
using Hack24.Core.Entities;
using Hack24.Core.Enums;
using Hack24.Core.Helpers;
using Hack24.Core.Repositories;
using Hack24.Core.Service;

namespace RavenTest
{
	class Program
	{
		private static void Main(string[] args)
		{


			var userRepo = new UserRepository();
			var metrics = new CompletedAnswerMetricRepository();
			var questionRepo = new QuestionRepository();

			//for (var i = 0; i < 10; i++)
			//{
			//	questionRepo.Store(new Question
			//	{
			//		Id = new Guid(),
			//		Text = "Question " + i,
			//		Answers = new[]
			//		{
			//			new Answer
			//			{
			//				Id = Guid.NewGuid(),
			//				Text = "Answer 1",
			//				MetricModifiers = new[]
			//				{
			//					new {Key = Metric.StrategicAwareness, Value = 1},
			//					new {Key = Metric.ProblemSolving, Value = 3}

			//				}.ToDictionary(x => x.Key, x => x.Value)

			//			},
			//			new Answer
			//			{
			//				Id = Guid.NewGuid(),
			//				Text = "Answer 2",
			//				MetricModifiers = new[]
			//				{
			//					new {Key = Metric.StrategicAwareness, Value = 4},
			//					new {Key = Metric.ProblemSolving, Value = 1}

			//				}.ToDictionary(x => x.Key, x => x.Value)

			//			},
			//			new Answer
			//			{
			//				Id = Guid.NewGuid(),
			//				Text = "Answer 3",
			//				MetricModifiers = new[]
			//				{
			//					new {Key = Metric.StrategicAwareness, Value = 3},
			//					new {Key = Metric.ProblemSolving, Value = 2}

			//				}.ToDictionary(x => x.Key, x => x.Value)

			//			}
			//		}
			//	});

			//}


		var id = GuidHelper.TestGuid("greg@bum.com");
			var user = userRepo.Get(id);

			metrics.Store(new AnswerMetric
			{
				Id = Guid.NewGuid(),
				AnswerId = Guid.NewGuid(),
				ManagerId = user.Manager.Id,
				QuestionId = Guid.NewGuid(),
				UserId = Guid.NewGuid(),
				Metric = Metric.ProblemSolving,
				Score =  5
			});

			metrics.Store(new AnswerMetric
			{
				Id = Guid.NewGuid(),
				AnswerId = Guid.NewGuid(),
				ManagerId = user.Manager.Id,
				QuestionId = Guid.NewGuid(),
				UserId = Guid.NewGuid(),
				Metric = Metric.ProblemSolving,
				Score = 2
			});
			Console.ReadLine();
		}
	}
}
