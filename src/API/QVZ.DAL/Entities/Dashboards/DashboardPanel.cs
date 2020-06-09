using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using QVZ.DAL.Entities.Abstracts;

namespace QVZ.DAL.Entities.Dashboards
{
	public class DashboardPanel : UpdateableEntity
	{
		public int DashboardId { get; set; }

		public int TypeId { get; set; }

		[StringLength(64)]
		[Required(AllowEmptyStrings = false)]
		public string Name { get; set; }

		public virtual DashboardPanelPosition Position { get; set; }

		[ForeignKey(nameof(DashboardId))]
		public virtual Dashboard Dashboard { get; set; }

		[ForeignKey(nameof(TypeId))]
		public virtual DashboardPanelType Type { get; set; }

	}
}
