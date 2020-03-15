using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
