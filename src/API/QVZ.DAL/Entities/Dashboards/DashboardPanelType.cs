using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using QVZ.DAL.Entities.Abstracts;
using QVZ.DAL.Entities.Interfaces;

namespace QVZ.DAL.Entities.Dashboards
{
	public class DashboardPanelType : UpdateableEntity
	{
        [StringLength(64)]
        public string Name { get; set; }

        public ICollection<DashboardPanel> Panels { get; set; } = new HashSet<DashboardPanel>();
	}
}
