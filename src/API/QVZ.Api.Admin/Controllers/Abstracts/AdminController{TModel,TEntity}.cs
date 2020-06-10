// Copyright (c) Nick Frederiksen. All Rights Reserved.

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QVZ.Api.Shared.Controllers;
using QVZ.DAL;

namespace QVZ.Api.Admin.Controllers.Abstracts
{
	public class AdminController<TModel, TEntity> : QVZApiController<TModel, TEntity>
		where TModel : class, new()
		where TEntity : class
	{
		public AdminController(IDatabaseContext databaseContext, IMapper mapper) 
			: base(databaseContext, mapper)
		{
		}
	}
}
