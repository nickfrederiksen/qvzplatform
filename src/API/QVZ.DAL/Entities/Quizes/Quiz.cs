using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using QVZ.DAL.Entities.Abstracts;
using QVZ.DAL.Entities.Interfaces;
using QVZ.DAL.Entities.ReferenceTables;

namespace QVZ.DAL.Entities.Quizes
{
	public class Quiz : UserManagedEntity, IUserOwned
	{
		[StringLength(60)]
		[Required(AllowEmptyStrings = false)]
		public string Name { get; set; }

		public DateTime Date { get; set; }

		public int UserId { get; set; }

		[ForeignKey(nameof(UserId))]
		public virtual User User { get; set; }

		public ICollection<Round> Rounds { get; set; } = new HashSet<Round>();

		public ICollection<QuizOrganizationReference> OrganizationReferences { get; set; } = new HashSet<QuizOrganizationReference>();
	}
}
