// Copyright (c) Nick Frederiksen. All Rights Reserved.

using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using QVZ.Api.Shared.Models;

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
