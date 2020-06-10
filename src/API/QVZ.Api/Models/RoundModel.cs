using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using QVZ.Api.Shared.Models;

namespace QVZ.Api.Models
{
	public class RoundModel : UserManagedModel
	{
		[StringLength(60)]
		[BindRequired]
		public string Name { get; set; }

		public int SortOrder { get; set; }

		[BindNever]
		public Guid QuizId { get; internal set; }
	}
}
