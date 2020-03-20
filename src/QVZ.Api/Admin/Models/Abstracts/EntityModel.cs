// Copyright (c) Nick Frederiksen. All Rights Reserved.

using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace QVZ.Api.Admin.Models.Abstracts
{
	public abstract class EntityModel
    {
        [BindNever]
        public Guid Id { get; internal set; }
    }
}
