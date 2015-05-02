using System;
using System.Collections;

namespace Hack24.Core.Entities
{
	public class Question
	{
		public readonly Guid Id;
		public readonly string ImageUrl;

		public readonly IEnumerable<Answer> Answers;
	}
}