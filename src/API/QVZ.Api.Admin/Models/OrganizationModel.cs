using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using QVZ.Api.Admin.Models.Abstracts;

namespace QVZ.Api.Admin.Models
{
	public class OrganizationModel : UpdateableModel
	{
		[BindRequired]
		[StringLength(120)]
		public string Name { get; set; }
	}
}
