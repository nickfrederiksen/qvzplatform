using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using QVZ.DAL.Entities.Abstracts;

namespace QVZ.DAL.Entities.Quizes
{
	public class Round : UserManagedEntity
	{
		[StringLength(60)]
		[Required(AllowEmptyStrings = false)]
		public string Name { get; set; }

		public int SortOrder { get; set; }

		public int QuizId { get; set; }

		[ForeignKey(nameof(QuizId))]
		public virtual Quiz Quiz { get; set; }

		public ICollection<Question> Questions { get; set; } = new HashSet<Question>();
	}
}
