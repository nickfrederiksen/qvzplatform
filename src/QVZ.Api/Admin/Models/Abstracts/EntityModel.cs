// Copyright (c) Nick Frederiksen. All Rights Reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace QVZ.Api.Admin.Models.Abstracts
{
    public abstract class EntityModel
    {
        [BindNever]
        public Guid Id { get; internal set; }
    }
}
