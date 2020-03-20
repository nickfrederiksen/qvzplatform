using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using QVZ.DAL.Entities.Abstracts;
using QVZ.DAL.Entities.ReferenceTables;

namespace QVZ.DAL.Entities
{
	public class Organization : UserManagedEntity
	{
		public Organization()
		{
			this.UserReferences = new HashSet<OrganizationUserReference>();
		}

		[Required(AllowEmptyStrings = false)]
		[StringLength(120)]
		public string Name { get; set; }

		public virtual ICollection<OrganizationUserReference> UserReferences { get; set; }
	}
}
