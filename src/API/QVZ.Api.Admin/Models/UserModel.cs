using Microsoft.AspNetCore.Mvc.ModelBinding;
using QVZ.Api.Shared.Models;

namespace QVZ.Api.Admin.Models
{
	public class UserModel : EntityModel
	{
		[BindNever]
		public string ObjectIdentifier { get; internal set; }
	}
}
