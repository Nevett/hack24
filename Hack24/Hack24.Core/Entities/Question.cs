using System;
using System.Collections;
using System.Collections.Generic;

namespace Hack24.Core.Entities
{
	public class Question
	{
		public Guid Id { get; set; }

		public string Text { get; set; }
		public string ImageUrl { get; set; }

		public IEnumerable<Answer> Answers { get; set; }
	}
}