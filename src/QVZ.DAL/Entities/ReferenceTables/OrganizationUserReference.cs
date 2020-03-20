using System.ComponentModel.DataAnnotations.Schema;

namespace QVZ.DAL.Entities.ReferenceTables
{
	public class OrganizationUserReference
	{
		public int UserId { get; set; }

		public int OrganizationId { get; set; }

		[ForeignKey(nameof(UserId))]
		public virtual User User { get; set; }

		[ForeignKey(nameof(OrganizationId))]
		public virtual Organization Organization { get; set; }
	}
}
