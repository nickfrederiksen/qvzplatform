using System.Collections;
using System.ComponentModel.DataAnnotations;
using QVZ.DAL.Entities.Abstracts;

namespace QVZ.DAL.Entities
{
	public class User : UpdateableEntity
	{
		[Required(AllowEmptyStrings = false)]
		public string ObjectId { get; set; }
	}
}
