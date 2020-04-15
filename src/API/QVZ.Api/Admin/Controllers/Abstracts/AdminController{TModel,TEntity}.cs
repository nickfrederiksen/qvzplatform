// Copyright (c) Nick Frederiksen. All Rights Reserved.

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QVZ.Api.Controllers.Abstracts;
using QVZ.DAL;

namespace QVZ.Api.Admin.Controllers.Abstracts
{
	[Area("admin")]
	public class AdminController<TModel, TEntity> : ApiController<TModel, TEntity>
		where TModel : class, new()
		where TEntity : class
	{
		public AdminController(IDatabaseContext databaseContext, IMapper mapper) 
			: base(databaseContext, mapper)
		{
		}
	}
}
