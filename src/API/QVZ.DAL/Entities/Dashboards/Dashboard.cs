using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using QVZ.DAL.Entities.Abstracts;
using QVZ.DAL.Entities.Interfaces;

namespace QVZ.DAL.Entities.Dashboards
{
	public class Dashboard : UserManagedEntity, IUserOwned
	{
		[Required(AllowEmptyStrings = false)]
		[StringLength(120)]
		public string Name { get; set; }

		public int UserId { get; set; }

		[ForeignKey(nameof(UserId))]
		public virtual User User { get; set; }

		public ICollection<DashboardPanel> Panels { get; set; } = new HashSet<DashboardPanel>();
	}
}
