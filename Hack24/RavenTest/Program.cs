using System;
using Hack24.Core.Entities;
using Hack24.Core.Repositories;

namespace RavenTest
{
	class Program
	{
		static void Main(string[] args)
		{

			var questionRepo = new QuestionRepository();

			questionRepo.Store(new Question
			{
				Id = Guid.NewGuid(),
				Text = "I am a question",
				Answers = new Answer[] { new Answer
				{
					Id =Guid.NewGuid(),
					Text = "Answer 1"
				}}
			});

			foreach (var question in questionRepo.All())
			{
				Console.WriteLine(question.Text);
			}
			Console.ReadLine();
		}
	}
}
