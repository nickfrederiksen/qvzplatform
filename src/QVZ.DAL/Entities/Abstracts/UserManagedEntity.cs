using System.ComponentModel.DataAnnotations.Schema;

namespace QVZ.DAL.Entities.Abstracts
{
	public abstract class UserManagedEntity : UpdateableEntity
	{
		public int UserCreatedById { get; set; }

		[ForeignKey(nameof(UserCreatedById))]
		public virtual User UserCreatedBy { get; set; }

		public int UserUpdatedById { get; set; }

		[ForeignKey(nameof(UserUpdatedById))]
		public virtual User UserUpdatedBy { get; set; }
	}
}
