// Copyright (c) Nick Frederiksen. All Rights Reserved.

using System;
using System.Linq;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QVZ.Api.Admin.Models;
using QVZ.Api.Constants.Authorization;
using QVZ.DAL;
using QVZ.DAL.Entities;

namespace QVZ.Api.Admin.Controllers
{
	[ApiController]
	[Area("admin")]
	[Route("[area]/api/dashboards")]
	[Authorize(Scopes.Admin)]
	public class DashboardController : ControllerBase
	{
		private readonly IEditableDatabaseContext databaseContext;
		private readonly IMapper mapper;

		public DashboardController(
			IEditableDatabaseContext editableDatabaseContext,
			IMapper mapper)
		{
			this.databaseContext = editableDatabaseContext;
			this.mapper = mapper;
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			var allDashboards = this.databaseContext.GetUserQuery<Dashboard>(this.User);
			var models = this.mapper.ProjectTo<DashboardModel>(allDashboards);

			return this.Ok(models);
		}

		[HttpGet("{id:guid}")]
		public IActionResult GetSingle(Guid id)
		{
			var entity = this.databaseContext.GetUserQuery<Dashboard>(this.User).SingleOrDefault(d => d.Guid == id);
			if (entity == null)
			{
				return this.NotFound();
			}

			var model = this.mapper.Map<DashboardModel>(entity);

			return this.Ok();
		}

		[HttpPost]
		public IActionResult Create(DashboardModel model)
		{
			var isConflict = this.databaseContext.GetUserQuery<Dashboard>(this.User).Any(d => d.Name == model.Name);
			if (isConflict)
			{
				return this.Conflict();
			}

			var entity = this.mapper.Map<Dashboard>(model);

			entity.User = this.databaseContext.GetUser(this.User);

			this.databaseContext.Dashboards.Add(entity);

			this.databaseContext.SaveChanges(this.User);

			model = this.mapper.Map<DashboardModel>(entity);

			return this.CreatedAtAction(nameof(this.GetSingle), new { id = model.Id }, model);
		}

		[HttpPut("{id}")]
		public IActionResult Update(Guid id, DashboardModel model)
		{
			var entity = this.databaseContext.GetUserQuery<Dashboard>(this.User).SingleOrDefault(d => d.Guid == id);

			if (entity == null)
			{
				return this.NotFound();
			}

			var isConflict = this.databaseContext.GetUserQuery<Dashboard>(this.User).Any(d => d.Name == model.Name && d.Guid != id);
			if (isConflict)
			{
				return this.Conflict();
			}

			this.mapper.Map(model, entity);

			this.databaseContext.SaveChanges(this.User);

			return this.NoContent();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(Guid id)
		{
			var entity = this.databaseContext.GetUserQuery<Dashboard>(this.User).SingleOrDefault(d => d.Guid == id);

			if (entity == null)
			{
				return this.NotFound();
			}

			this.databaseContext.Dashboards.Remove(entity);

			this.databaseContext.SaveChanges(this.User);

			return this.NoContent();
		}
	}
}
