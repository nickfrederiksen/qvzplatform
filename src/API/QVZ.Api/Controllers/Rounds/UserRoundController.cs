using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using QVZ.Api.ActionFilters;
using QVZ.Api.Models;
using QVZ.Api.Shared.Controllers;
using QVZ.Api.Shared.Models;
using QVZ.DAL;
using QVZ.DAL.Entities.Quizes;

namespace QVZ.Api.Controllers.Rounds
{
	[Route("api/users/me/quizes/{quizId}/rounds")]
	[QuizFilter("quizId", ValidateOwnership = true)]
	public class UserRoundController : QVZApiController<RoundModel, Round>
	{
		private readonly IEditableDatabaseContext databaseContext;

		public UserRoundController(IEditableDatabaseContext databaseContext, IMapper mapper)
			: base(databaseContext, mapper)
		{
			this.databaseContext = databaseContext;
		}

		[HttpGet]
		[ProducesResponseType(typeof(IEnumerable<RoundModel>), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public IActionResult GetAll(Guid quizId)
		{
			var rounds = GetQuery(quizId);

			var models = this.ProjectToModel(rounds);

			return this.Ok(models);
		}

		[HttpGet("{id}", Name = "singleUserRound")]
		[ProducesResponseType(typeof(RoundModel), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public IActionResult GetSingle(Guid quizId, Guid id)
		{
			var round = this.GetQuery(quizId).SingleOrDefault(r => r.Guid == id);

			if (round == null)
			{
				return this.NotFound();
			}

			var model = this.GetModel(round);

			return this.Ok(model);
		}

		[HttpPost]
		[ProducesResponseType(typeof(RoundModel), StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status409Conflict)]
		[ProducesResponseType(typeof(IBadRequestModel), StatusCodes.Status409Conflict)]
		public IActionResult Create(Guid quizId, RoundModel model)
		{
			var exists = this.GetQuery(quizId).Any(r => r.Name == model.Name);
			if (exists)
			{
				this.ModelState.AddModelError(nameof(model.Name), $"A round with name, {model.Name}, already exists.");
				return this.Conflict(this.ModelState);
			}

			var entity = this.GetEntity(model);

			entity.Quiz = this.databaseContext.Quizes.GetUserQuery(this.User).Single(q => q.Guid == quizId);

			this.DbSet.Add(entity);

			this.databaseContext.SaveChanges(this.User);

			model = this.GetModel(entity);

			return this.CreatedAtRoute("singleUserRound", new { quizId, id = entity.Id }, model);
		}

		[HttpPut("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status409Conflict)]
		[ProducesResponseType(typeof(IBadRequestModel), StatusCodes.Status409Conflict)]
		public IActionResult Update(Guid quizId, Guid id, RoundModel model)
		{
			IQueryable<Round> query = this.GetQuery(quizId);

			var entity = query.SingleOrDefault(r => r.Guid == id);
			if (entity == null)
			{
				return this.NotFound();
			}

			var exists = query.Any(r => r.Guid != id && r.Name == model.Name);
			if (exists)
			{
				this.ModelState.AddModelError(nameof(model.Name), $"A round with name, {model.Name}, already exists.");
				return this.Conflict(this.ModelState);
			}

			entity = this.UpdateEntity(model, entity);

			this.databaseContext.SaveChanges(this.User);

			return this.NoContent();
		}

		[HttpDelete("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(typeof(IBadRequestModel), StatusCodes.Status409Conflict)]
		public IActionResult Delete(Guid quizId, Guid id)
		{
			var entity = this.GetQuery(quizId).SingleOrDefault(r => r.Guid == id);
			if (entity == null)
			{
				return this.NotFound();
			}

			var answers = this.databaseContext.Answers.Where(a => a.Question.Round.Guid == id).ToList();
			var questions = this.databaseContext.Questions.Where(q => q.Round.Guid == id).ToList();

			this.databaseContext.Answers.RemoveRange(answers);
			this.databaseContext.Questions.RemoveRange(questions);
			this.DbSet.Remove(entity);

			this.databaseContext.SaveChanges(this.User);

			return this.NoContent();
		}

		private IQueryable<Round> GetQuery(Guid quizId)
		{
			return this.databaseContext
				.Rounds
				.Where(r => r.Quiz.Guid == quizId)
				.Include(r => r.Quiz)
				.GetUserManagedQuery();
		}
	}
}
