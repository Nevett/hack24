using System;
using Hack24.Core.Entities;

namespace Hack24.Core.Service
{
	public interface ICompletedAnswerService
	{
		void RecordAnswer(Guid questionId, Guid answerId, User currentUser);
	}
}