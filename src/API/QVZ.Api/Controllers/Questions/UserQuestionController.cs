using System;
using System.Collections;
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
using Swashbuckle.AspNetCore.Annotations;

namespace QVZ.Api.Controllers.Questions
{
	[Route("api/users/me/quizes/{quizId}/rounds/{roundId}/questions")]
	[QuizFilter("quizId", ValidateOwnership = true)]
	[RoundFilter("roundId", "quizId")]
	public class UserQuestionController : QVZApiController<QuestionModel, Question>
	{
		private readonly IEditableDatabaseContext databaseContext;

		public UserQuestionController(IEditableDatabaseContext databaseContext, IMapper mapper)
			: base(databaseContext, mapper)
		{
			this.databaseContext = databaseContext;
		}

		[HttpGet]
		[ProducesResponseType(typeof(IEnumerable<QuestionModel>), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public IActionResult GetAll(Guid quizId, Guid roundId)
		{
			var query = this.GetQuery(quizId, roundId);
			var models = this.ProjectToModel(query);

			return this.Ok(models);
		}

		[HttpGet("{id}")]
		[ProducesResponseType(typeof(QuestionModel), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public IActionResult GetSingle(Guid quizId, Guid roundId, Guid id)
		{
			var entity = this.GetQuery(quizId, roundId).SingleOrDefault(q => q.Guid == id);
			if (entity == null)
			{
				return this.NotFound();
			}

			var model = this.GetModel(entity);

			return this.Ok(model);
		}

		[HttpPost]
		[ProducesResponseType(typeof(QuestionModel), StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(typeof(IBadRequestModel), StatusCodes.Status409Conflict)]
		public IActionResult Create(Guid quizId, Guid roundId, QuestionModel model)
		{
			var questionType = this.databaseContext.QuestionTypes.SingleOrDefault(t => t.Guid == model.TypeId);
			if (questionType == null)
			{
				this.ModelState.AddModelError(nameof(model.TypeId), $"A question type with id, {model.TypeId}, does not exist.");
			}

			if (this.ModelState.IsValid)
			{
				var exists = this.GetQuery(quizId, roundId).Any(q => q.Text == model.Text);
				if (exists)
				{
					this.ModelState.AddModelError(nameof(model.Text), $"The question, {model.Text}, already exists.");
					return this.Conflict(this.ModelState);
				}

				var entity = this.GetEntity(model);
				entity.Round = this.databaseContext.Rounds.Single(r => r.Guid == roundId);
				entity.Type = questionType;

				this.DbSet.Add(entity);
				this.databaseContext.SaveChanges(this.User);

				model = this.GetModel(entity);

				return this.CreatedAtAction(nameof(this.GetSingle), new { quizId, roundId, id = entity.Guid }, model);
			}
			else
			{
				return this.BadRequest(this.ModelState);
			}
		}

		[HttpPut("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(typeof(IBadRequestModel), StatusCodes.Status409Conflict)]
		public IActionResult Update(Guid quizId, Guid roundId, Guid id, QuestionModel model)
		{
			IQueryable<Question> query = this.GetQuery(quizId, roundId);
			var entity = query.SingleOrDefault(q => q.Guid == id);
			if (entity == null)
			{
				return this.NotFound();
			}

			var questionType = this.databaseContext.QuestionTypes.SingleOrDefault(t => t.Guid == model.TypeId);
			if (questionType == null)
			{
				this.ModelState.AddModelError(nameof(model.TypeId), $"A question type with id, {model.TypeId}, does not exist.");
			}

			if (this.ModelState.IsValid)
			{
				var exists = query.Any(q => q.Guid != id && q.Text == model.Text);
				if (exists)
				{
					this.ModelState.AddModelError(nameof(model.Text), $"The question, {model.Text}, already exists.");
					return this.Conflict(this.ModelState);
				}

				entity = this.UpdateEntity(model, entity);

				entity.Type = questionType;

				this.databaseContext.SaveChanges(this.User);

				return this.NoContent();
			}
			else
			{
				return this.BadRequest(this.ModelState);
			}
		}

		[HttpDelete("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public IActionResult Delete(Guid quizId, Guid roundId, Guid id)
		{
			var entity = this.GetQuery(quizId, roundId).SingleOrDefault(q => q.Guid == id);
			if (entity == null)
			{
				return this.NotFound();
			}

			var answers = this.databaseContext.Answers.Where(a => a.Question.Guid == id).ToList();
			this.databaseContext.Answers.RemoveRange(answers);
			this.DbSet.Remove(entity);

			this.databaseContext.SaveChanges(this.User);

			return this.NoContent();
		}

		private IQueryable<Question> GetQuery(Guid quizId, Guid roundId)
		{
			return this.DbSet
				.Include(q => q.Round)
				.Include(q => q.Type)
				.Where(q => q.Round.Guid == roundId && q.Round.Quiz.Guid == quizId)
				.GetUserManagedQuery();
		}
	}
}
