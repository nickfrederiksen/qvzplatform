using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QVZ.DAL.Entities.Abstracts;

namespace QVZ.DAL.Entities.Quizes
{
	public class Question : UserManagedEntity
	{
		[StringLength(256)]
		[Required(AllowEmptyStrings = false)]
		public string Text { get; set; }

		[StringLength(512)]
		[Required(AllowEmptyStrings = false)]
		public string CorrectAnswer { get; set; }

		[DefaultValue(1)]
		public int Points { get; set; } = 1;

		public int TypeId { get; set; }

		public int RoundId { get; set; }

		[ForeignKey(nameof(TypeId))]
		public virtual QuestionType Type { get; set; }

		[ForeignKey(nameof(RoundId))]
		public virtual Round Round { get; set; }

		public ICollection<Answer> Answers { get; set; } = new HashSet<Answer>();
	}
}
