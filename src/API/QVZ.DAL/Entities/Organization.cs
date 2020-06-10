using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using QVZ.DAL.Entities.Abstracts;
using QVZ.DAL.Entities.Quizes;
using QVZ.DAL.Entities.ReferenceTables;

namespace QVZ.DAL.Entities
{
	public class Organization : UserManagedEntity
	{
		[Required(AllowEmptyStrings = false)]
		[StringLength(120)]
		public string Name { get; set; }

		public virtual ICollection<OrganizationUserReference> UserReferences { get; set; } = new HashSet<OrganizationUserReference>();

		public ICollection<Answer> Answers { get; set; } = new HashSet<Answer>();
	}
}
