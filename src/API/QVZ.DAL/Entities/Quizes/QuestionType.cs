using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using QVZ.DAL.Entities.Abstracts;

namespace QVZ.DAL.Entities.Quizes
{
	public class QuestionType : Entity
	{
		[StringLength(60)]
		[Required(AllowEmptyStrings = false)]
		public string Name { get; set; }

		public ICollection<Question> Questions { get; set; } = new HashSet<Question>();
	}
}
