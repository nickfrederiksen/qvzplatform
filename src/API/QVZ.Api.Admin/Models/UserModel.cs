using Microsoft.AspNetCore.Mvc.ModelBinding;
using QVZ.Api.Admin.Models.Abstracts;

namespace QVZ.Api.Admin.Models
{
	public class UserModel : EntityModel
	{
		[BindNever]
		public string ObjectIdentifier { get; internal set; }
	}
}
