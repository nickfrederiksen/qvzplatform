using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Filters;
using QVZ.Api.Shared.ActionFilters;
using QVZ.DAL;
using QVZ.DAL.Entities.Quizes;

namespace QVZ.Api.ActionFilters
{
	public class QuizFilterAttribute : EntityFilterAttribute
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="QuizFilterAttribute"/> class.
		/// </summary>
		public QuizFilterAttribute()
			: this("quizId")
		{

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="QuizFilterAttribute"/> class.
		/// </summary>
		/// <param name="routeKey">Key from the route that maps to the Quiz id.</param>
		public QuizFilterAttribute(string routeKey)
			: base(routeKey)
		{
		}

		/// <summary>
		/// Gets or sets a value indicating whether to validate user ownership of the quiz or not.
		/// </summary>
		public bool ValidateOwnership { get; set; }

		protected override bool EntityExists(ActionExecutingContext context, IDatabaseContext databaseContext, Guid routeValue)
		{
			IQueryable<Quiz> query = databaseContext.Quizes.Where(q => q.Guid == routeValue);
			if (this.ValidateOwnership)
			{
				query = query.GetUserQuery(context.HttpContext.User);
			}

			return query.Any();
		}
	}
}
