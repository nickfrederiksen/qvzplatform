using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QVZ.DAL.Entities.Quizes;

namespace QVZ.DAL.Entities.ReferenceTables
{
	public class QuizOrganizationReference
	{
		public int QuizId { get; set; }

		public int OrganizationId { get; set; }

		[ForeignKey(nameof(QuizId))]
		public virtual Quiz Quiz { get; set; }

		[ForeignKey(nameof(OrganizationId))]
		public virtual Organization Organization { get; set; }
	}
}
