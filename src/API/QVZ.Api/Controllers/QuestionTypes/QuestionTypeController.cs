using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QVZ.Api.Models;
using QVZ.Api.Shared.Controllers;
using QVZ.DAL;
using QVZ.DAL.Entities.Quizes;

namespace QVZ.Api.Controllers.QuestionTypes
{
	[Route("api/questiontypes")]
	public class QuestionTypeController : QVZApiController<QuestionTypeModel, QuestionType>
	{
		public QuestionTypeController(IDatabaseContext databaseContext, IMapper mapper)
			: base(databaseContext, mapper)
		{
		}

		[HttpGet]
		[ProducesResponseType(typeof(IEnumerable<QuestionTypeModel>), StatusCodes.Status200OK)]
		public IActionResult GetAll()
		{
			var models = this.ProjectToModel(this.DbSet);

			return this.Ok(models);
		}

		[HttpGet("{id}")]
		[ProducesResponseType(typeof(QuestionTypeModel), StatusCodes.Status200OK)]
		public IActionResult GetSingle(Guid id)
		{
			var entity = this.DbSet.SingleOrDefault(t => t.Guid == id);
			if (entity == null)
			{
				return this.NotFound();
			}

			var model = this.GetModel(entity);
			return this.Ok(model);
		}
	}
}
