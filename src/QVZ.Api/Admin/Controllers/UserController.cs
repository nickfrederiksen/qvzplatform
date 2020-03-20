// Copyright (c) Nick Frederiksen. All Rights Reserved.

using System;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QVZ.Api.Admin.Controllers.Abstracts;
using QVZ.Api.Admin.Models;
using QVZ.Api.Constants.Authorization;
using QVZ.DAL;
using QVZ.DAL.Entities;

namespace QVZ.Api.Admin.Controllers
{
	[Route("[area]/api/users")]
	[Authorize(Scopes.Admin)]
	public class UserController : AdminController<UserModel, User>
	{
		private readonly IDatabaseContext databaseContext;

		public UserController(
			IDatabaseContext databaseContext,
			IMapper mapper)
			: base(databaseContext, mapper)
		{
			this.databaseContext = databaseContext;
		}

		[HttpGet("/api/organizations/{organizationId}/users", Name = "organizationUsers")]
		public IActionResult GetAllByOrganization(Guid organizationId)
		{
			var organization = this.DbSet.SingleOrDefault(o => o.Guid == organizationId);
			if (organization == null)
			{
				return this.NotFound();
			}

			var users = this.databaseContext.OrganizationUserReferences.Where(r => r.Organization.Guid == organizationId).Select(r => r.User);

			var models = this.ProjectToModel(users);

			return this.Ok(models);
		}
	}
}
