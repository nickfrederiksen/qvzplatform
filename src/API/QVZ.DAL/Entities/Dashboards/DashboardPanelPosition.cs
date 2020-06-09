using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QVZ.DAL.Entities.Dashboards
{
	public class DashboardPanelPosition
	{
		[Key]
		public int PanelId { get; set; }

		public int Top { get; set; }

		public int Left { get; set; }

		[ForeignKey(nameof(PanelId))]
		public virtual DashboardPanel Panel { get; set; }
	}
}
