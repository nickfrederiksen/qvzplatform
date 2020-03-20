using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace QVZ.DAL.Entities.Abstracts
{
	public abstract class UpdateableEntity : Entity
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public DateTime CreatedDate { get; set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		public DateTime UpdatedDate { get; set; }
	}
}
