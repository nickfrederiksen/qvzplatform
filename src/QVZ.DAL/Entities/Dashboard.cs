using System.ComponentModel.DataAnnotations;
using QVZ.DAL.Entities.Abstracts;

namespace QVZ.DAL.Entities
{
	public class Dashboard : UserManagedEntity
	{
		[Required(AllowEmptyStrings = false)]
		public string Name { get; set; }
	}
}
