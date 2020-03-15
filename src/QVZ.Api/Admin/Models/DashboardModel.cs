// Copyright (c) Nick Frederiksen. All Rights Reserved.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using QVZ.Api.Admin.Models.Abstracts;

namespace QVZ.Api.Admin.Models
{
	public class DashboardModel : UpdateableModel
	{
		[BindRequired]
		[StringLength(120)]
		public string Name { get; set; }

		[BindNever]
		public Guid UserId { get; internal set; }
	}
}
