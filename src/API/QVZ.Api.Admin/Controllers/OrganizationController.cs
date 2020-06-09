using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QVZ.Api.Admin.Controllers.Abstracts;
using QVZ.Api.Admin.Models;
using QVZ.DAL;
using QVZ.DAL.Entities;

namespace QVZ.Api.Admin.Controllers
{
	[Route("api/organizations")]
	public class OrganizationController : AdminController<OrganizationModel, Organization>
	{
		private readonly IEditableDatabaseContext databaseContext;

		public OrganizationController(IEditableDatabaseContext databaseContext, IMapper mapper)
			: base(databaseContext, mapper)
		{
			this.databaseContext = databaseContext;
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			var organizations = this.databaseContext.Organizations;
			var models = this.ProjectToModel(organizations);

			return this.Ok(models);
		}

	}
}
