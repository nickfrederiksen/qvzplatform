// Copyright (c) Nick Frederiksen. All Rights Reserved.

using System;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QVZ.Api.Admin.Controllers.Abstracts;
using QVZ.Api.Admin.Models;
using QVZ.DAL;
using QVZ.DAL.Entities.Dashboards;

namespace QVZ.Api.Admin.Controllers
{
	[Route("api/dashboards")]
	public class DashboardController : AdminController<DashboardModel, Dashboard>
	{
		private readonly IEditableDatabaseContext databaseContext;

		public DashboardController(
			IEditableDatabaseContext databaseContext,
			IMapper mapper)
			: base(databaseContext, mapper)
		{
			this.databaseContext = databaseContext;
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			var allDashboards = this.DbSet.GetUserQuery(this.User);
			var models = this.ProjectToModel(allDashboards);

			return this.Ok(models);
		}

		[HttpGet("{id:guid}")]
		public IActionResult GetSingle(Guid id)
		{
			var entity = this.DbSet.GetUserQuery(this.User).SingleOrDefault(d => d.Guid == id);
			if (entity == null)
			{
				return this.NotFound();
			}

			var model = this.GetModel(entity);

			return this.Ok(model);
		}

		[HttpPost]
		public IActionResult Create(DashboardModel model)
		{
			var isConflict = this.DbSet.GetUserQuery(this.User).Any(d => d.Name == model.Name);
			if (isConflict)
			{
				return this.Conflict();
			}

			var entity = this.GetEntity(model);

			//entity.User = this.databaseContext.GetUser(this.User);

			this.DbSet.Add(entity);

			this.databaseContext.SaveChanges(this.User);

			model = this.GetModel(entity);

			return this.CreatedAtAction(nameof(this.GetSingle), new { id = model.Id }, model);
		}

		[HttpPut("{id}")]
		public IActionResult Update(Guid id, DashboardModel model)
		{
			var entity = this.DbSet.GetUserQuery(this.User).SingleOrDefault(d => d.Guid == id);

			if (entity == null)
			{
				return this.NotFound();
			}

			var isConflict = this.DbSet.GetUserQuery(this.User).Any(d => d.Name == model.Name && d.Guid != id);
			if (isConflict)
			{
				return this.Conflict();
			}

			entity = this.GetEntity(model, entity);

			this.databaseContext.SaveChanges(this.User);

			return this.NoContent();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(Guid id)
		{
			var entity = this.DbSet.GetUserQuery(this.User).SingleOrDefault(d => d.Guid == id);

			if (entity == null)
			{
				return this.NotFound();
			}

			this.DbSet.Remove(entity);

			this.databaseContext.SaveChanges(this.User);

			return this.NoContent();
		}
	}
}
