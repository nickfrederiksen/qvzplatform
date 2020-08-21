// Copyright (c) Nick Frederiksen. All Rights Reserved.

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using QVZ.Api.Shared.Models;

namespace QVZ.Api.Models
{
	public class QuestionModel : UserManagedModel
	{
		[StringLength(256)]
		[Required(AllowEmptyStrings = false)]
		public string Text { get; set; }

		[StringLength(512)]
		[Required(AllowEmptyStrings = false)]
		public string CorrectAnswer { get; set; }

		[DefaultValue(1)]
		public int Points { get; set; } = 1;

		public Guid TypeId { get; set; }

		[BindNever]
		public Guid RoundId { get; internal set; }
	}
}
