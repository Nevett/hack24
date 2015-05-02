using System;
using System.Linq;
using Hack24.Core.Entities;
using Hack24.Core.Repositories;

namespace Hack24.Core.Service
{
	public class CompletedAnswerService : ICompletedAnswerService
	{
		private readonly ICompletedAnswerRepository _completedAnswerRepository;
		private readonly ICompletedAnswerMetricRepository _answerMetricRepository;
		private readonly IQuestionRepository _questionRepository;

		public CompletedAnswerService(ICompletedAnswerRepository completedAnswerRepository, ICompletedAnswerMetricRepository answerMetricRepository, IQuestionRepository questionRepository)
		{
			_completedAnswerRepository = completedAnswerRepository;
			_answerMetricRepository = answerMetricRepository;
			_questionRepository = questionRepository;
		}

		public void RecordAnswer(Guid questionId, Guid answerId, User currentUser)
		{
			var question = this._questionRepository.Get(questionId);
			var answer = question.Answers.First(x => x.Id == answerId);

			foreach (var metricModifier in answer.MetricModifiers)
			{
				_answerMetricRepository.Store(new AnswerMetric
				{
					Id = Guid.NewGuid(),
					QuestionId = questionId,
					AnswerId = answerId,
					ManagerId = currentUser.Manager.Id,
					UserId = currentUser.Id,
					Metric = metricModifier.Key,
					Score = metricModifier.Value
				});


			}
		}
	}
}