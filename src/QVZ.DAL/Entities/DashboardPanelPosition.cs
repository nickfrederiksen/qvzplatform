using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QVZ.DAL.Entities
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
