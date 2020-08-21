// Copyright (c) Nick Frederiksen. All Rights Reserved.

using System;

namespace QVZ.Api.Shared.Models
{
	public interface IUpdateableModel : IEntityModel
	{
		DateTime CreatedDate { get; }

		DateTime UpdatedDate { get; }
	}
}