using System.ComponentModel.DataAnnotations.Schema;

namespace QVZ.DAL.Entities.Abstracts
{
	public abstract class UserManagedEntity : UpdateableEntity
	{
		public int CreatedById { get; set; }

		[ForeignKey(nameof(CreatedById))]
		public virtual User CreatedBy { get; set; }

		public int UpdatedById { get; set; }

		[ForeignKey(nameof(UpdatedById))]
		public virtual User UpdatedBy { get; set; }
	}
}
