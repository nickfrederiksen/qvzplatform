using System;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using QVZ.Api.Models;
using QVZ.Api.Shared.Controllers;
using QVZ.DAL;
using QVZ.DAL.Entities.Quizes;

namespace QVZ.Api.Controllers.Quizes
{
	/// <summary>
	/// Manages all user owned quizes.
	/// </summary>
	[Route("api/users/me/quizes")]
	public class UserQuizController : QVZUserApiController<QuizModel, Quiz>
	{
		private readonly IEditableDatabaseContext databaseContext;

		/// <summary>
		/// Initializes a new instance of the <see cref="UserQuizController"/> class.
		/// </summary>
		/// <inheritdoc cref="QVZUserApiController{TModel, TEntity}"/>
		public UserQuizController(IEditableDatabaseContext databaseContext, IMapper mapper)
			: base(databaseContext, mapper)
		{
			this.databaseContext = databaseContext;
		}

		/// <summary>
		/// Gets all users own quizes.
		/// </summary>
		/// <returns>A list of quizes owned by the user.</returns>
		[HttpGet]
		[ProducesResponseType(typeof(QuizModel[]), StatusCodes.Status200OK)]

		public IActionResult GetAll()
		{
			var models = this.ProjectToModel(this.UserQuery);

			return this.Ok(models);
		}

		/// <summary>
		/// Gets a single quiz, owned by the user.
		/// </summary>
		/// <param name="id">Id of the quiz.</param>
		/// <returns>The quiz, or not found.</returns>
		[HttpGet("{id}", Name = "getSingleUserQuiz")]
		[ProducesResponseType(typeof(QuizModel), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public IActionResult GetSingle(Guid id)
		{
			var quiz = this.UserQuery.SingleOrDefault(q => q.Guid == id);

			if (quiz == null)
			{
				return this.NotFound();
			}

			var model = this.GetModel(quiz);

			return this.Ok(model);
		}

		/// <summary>
		/// Creates a new quiz and sets the owner to the current user.
		/// </summary>
		/// <param name="model">Quiz to create.</param>
		/// <returns>The newly created quiz.</returns>
		[HttpPost]
		[ProducesResponseType(typeof(QuizModel), StatusCodes.Status201Created)]
		[ProducesResponseType(typeof(ModelStateDictionary), StatusCodes.Status409Conflict)]
		public IActionResult Create(QuizModel model)
		{
			var isConflict = this.UserQuery.Any(q => q.Name == model.Name);
			if (isConflict)
			{
				this.ModelState.AddModelError(nameof(model.Name), $"Quiz, {model.Name}, already exists");
				return this.Conflict(this.ModelState);
			}

			var entity = this.GetEntity(model);

			entity.User = this.GetUser();

			this.DbSet.Add(entity);

			this.databaseContext.SaveChanges(this.User);

			model = this.GetModel(entity);

			return this.CreatedAtRoute("getSingleUserQuiz", new { id = entity.Guid }, model);
		}

		/// <summary>
		/// Updates a single quiz, that the user owns.
		/// </summary>
		/// <param name="id">Id of the quiz to update.</param>
		/// <param name="model">Updated values.</param>
		/// <returns>No content og not found.</returns>
		[HttpPut("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(typeof(ModelStateDictionary), StatusCodes.Status409Conflict)]
		public IActionResult Update(Guid id, QuizModel model)
		{
			var entity = this.UserQuery.SingleOrDefault(q => q.Guid == id);
			if (entity == null)
			{
				return this.NotFound();
			}

			var isConflict = this.UserQuery.Any(q => q.Guid != id && q.Name == model.Name);
			if (isConflict)
			{
				this.ModelState.AddModelError(nameof(model.Name), $"Quiz, {model.Name}, already exists");
				return this.Conflict(this.ModelState);
			}

			entity = this.UpdateEntity(model, entity);

			this.databaseContext.SaveChanges(this.User);

			return this.NoContent();
		}

		/// <summary>
		/// Deletes a single quiz that the user owns.
		/// </summary>
		/// <param name="id">Id of the quiz to delete.</param>
		/// <returns>No content or not found.</returns>
		[HttpDelete("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public IActionResult Delete(Guid id)
		{
			var entity = this.UserQuery.SingleOrDefault(q => q.Guid == id);
			if (entity == null)
			{
				return this.NotFound();
			}

			var rounds = this.databaseContext.Rounds.Where(r => r.QuizId == entity.Id).ToList();
			var questions = this.databaseContext.Questions.Where(q => q.Round.QuizId == entity.Id).ToList();
			var answers = this.databaseContext.Answers.Where(a => a.Question.Round.QuizId == entity.Id).ToList();

			this.databaseContext.Answers.RemoveRange(answers);
			this.databaseContext.Questions.RemoveRange(questions);
			this.databaseContext.Rounds.RemoveRange(rounds);

			this.DbSet.Remove(entity);

			this.databaseContext.SaveChanges(this.User);

			return this.NoContent();
		}
	}
}
