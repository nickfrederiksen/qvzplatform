using QVZ.DAL.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QVZ.DAL.Entities
{
    public class DashboardPanelType : UpdateableEntity
    {
        [StringLength(64)]
        public string Name { get; set; }

        public ICollection<DashboardPanel> Panels { get; set; } = new HashSet<DashboardPanel>();
    }
}
