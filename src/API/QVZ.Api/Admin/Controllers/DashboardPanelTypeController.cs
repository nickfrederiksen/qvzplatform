using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QVZ.Api.Admin.Controllers.Abstracts;
using QVZ.Api.Admin.Models;
using QVZ.Api.BusinessLogic.ActionFilters;
using QVZ.Api.Constants.Authorization;
using QVZ.DAL;
using QVZ.DAL.Entities;
using QVZ.DAL.Entities.Dashboards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QVZ.Api.Admin.Controllers
{
	[Area("admin")]
	[Route("[area]/api/dashboardtypes")]
	[Authorize(Scopes.Admin)]
	public class DashboardPanelTypeController : AdminController<DashboardPanelTypeModel, DashboardPanelType>
	{
		private readonly IEditableDatabaseContext databaseContext;

		public DashboardPanelTypeController(IEditableDatabaseContext databaseContext, IMapper mapper)
			: base(databaseContext, mapper)
		{
			this.databaseContext = databaseContext;
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			var allDashboards = this.DbSet;
			var models = this.ProjectToModel(allDashboards);

			return this.Ok(models);
		}

		[HttpGet("{id:guid}")]
		public IActionResult GetSingle(Guid id)
		{
			var entity = this.DbSet.SingleOrDefault(d => d.Guid == id);
			if (entity == null)
			{
				return this.NotFound();
			}

			var model = this.GetModel(entity);

			return this.Ok(model);
		}

		[HttpPost]
		public IActionResult Create(DashboardPanelTypeModel model)
		{
			var isConflict = this.DbSet.Any(d => d.Name == model.Name);
			if (isConflict)
			{
				return this.Conflict();
			}

			var entity = this.GetEntity(model);

			this.DbSet.Add(entity);

			this.databaseContext.SaveChanges(this.User);

			model = this.GetModel(entity);

			return this.CreatedAtAction(nameof(this.GetSingle), new { id = model.Id }, model);
		}

		[HttpPut("{id}")]
		public IActionResult Update(Guid id, DashboardPanelTypeModel model)
		{
			var entity = this.DbSet.SingleOrDefault(d => d.Guid == id);

			if (entity == null)
			{
				return this.NotFound();
			}

			var isConflict = this.DbSet.Any(d => d.Name == model.Name && d.Guid != id);
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
			var entity = this.DbSet.SingleOrDefault(d => d.Guid == id);

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
