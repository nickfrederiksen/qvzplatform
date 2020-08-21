// Copyright (c) Nick Frederiksen. All Rights Reserved.

using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace QVZ.Api.Shared.Models
{
	public abstract class UpdateableModel : EntityModel, IUpdateableModel
	{
		[BindNever]
		public DateTime CreatedDate { get; internal set; }

		[BindNever]
		public DateTime UpdatedDate { get; internal set; }
	}
}
