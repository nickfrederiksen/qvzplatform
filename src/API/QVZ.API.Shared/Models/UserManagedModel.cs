using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace QVZ.Api.Shared.Models
{
	public class UserManagedModel : UpdateableModel
	{
		[BindNever]
		public Guid CreatedById { get; internal set; }

		[BindNever]
		public Guid UpdatedById { get; internal set; }
	}
}
