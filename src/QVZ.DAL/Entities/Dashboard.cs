using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using QVZ.DAL.Entities.Abstracts;
using QVZ.DAL.Entities.Interfaces;

namespace QVZ.DAL.Entities
{
	public class Dashboard : UserManagedEntity, IUserOwned
	{
		[Required(AllowEmptyStrings = false)]
		[StringLength(120)]
		public string Name { get; set; }

		public int UserId { get; set; }

		[ForeignKey(nameof(UserId))]
		public virtual User User { get; set; }
	}
}
