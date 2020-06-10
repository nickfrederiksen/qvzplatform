// Copyright (c) Nick Frederiksen. All Rights Reserved.

using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace QVZ.Api.Shared.Models
{
	public abstract class EntityModel
    {
        [BindNever]
        public Guid Id { get; internal set; }
    }
}
