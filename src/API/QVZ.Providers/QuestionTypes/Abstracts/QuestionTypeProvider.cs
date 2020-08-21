using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QVZ.DAL.Entities.Quizes;

namespace QVZ.Providers.QuestionTypes.Abstracts
{
	public abstract class QuestionTypeProvider
	{
		private readonly Question question;

		public QuestionTypeProvider(Question question)
		{
			this.question = question;
		}

		protected virtual bool IsCorrect(Answer answer)
		{
			return this.question.CorrectAnswer.Trim().Equals(answer.Value.Trim(), StringComparison.InvariantCultureIgnoreCase);
		}
	}
}
