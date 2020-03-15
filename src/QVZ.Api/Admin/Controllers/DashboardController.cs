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
		private readonly IEditableDatabaseContext dbContext;
		private readonly IMapper mapper;

		public DashboardController(
			IEditableDatabaseContext editableDatabaseContext,
			IMapper mapper)
		{
			this.dbContext = editableDatabaseContext;
			this.mapper = mapper;
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			var allDashboards = this.dbContext.Dashboards;
			var models = this.mapper.ProjectTo<DashboardModel>(allDashboards);

			return this.Ok(models);
		}

		[HttpGet("{id:guid}")]
		public IActionResult GetSingle(Guid id)
		{
			var entity = this.dbContext.Dashboards.SingleOrDefault(d => d.Guid == id);
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
			var entity = this.mapper.Map<Dashboard>(model);

			this.dbContext.Dashboards.Add(entity);

			this.dbContext.SaveChanges(this.User);

			model = this.mapper.Map<DashboardModel>(entity);

			return this.CreatedAtAction(nameof(this.GetSingle), new { id = model.Id }, model);
		}
	}
}
