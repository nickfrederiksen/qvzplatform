using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QVZ.DAL.Entities.Abstracts;

namespace QVZ.DAL.Entities.Quizes
{
	public class Answer : UserManagedEntity
	{
		[StringLength(512)]
		[Required(AllowEmptyStrings = true)]
		public string Value { get; set; }

		public int OrganizationId { get; set; }

		public int QuestionId { get; set; }

		[ForeignKey(nameof(OrganizationId))]
		public virtual Organization Organization { get; set; }

		[ForeignKey(nameof(QuestionId))]
		public virtual Question Question { get; set; }
	}
}
