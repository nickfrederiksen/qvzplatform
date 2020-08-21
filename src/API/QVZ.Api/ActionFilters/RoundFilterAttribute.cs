using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Filters;
using QVZ.Api.Shared.ActionFilters;
using QVZ.DAL;
using QVZ.DAL.Entities.Quizes;

namespace QVZ.Api.ActionFilters
{
	public class RoundFilterAttribute : EntityFilterAttribute
	{

		/// <summary>
		/// Initializes a new instance of the <see cref="RoundFilterAttribute"/> class.
		/// </summary>
		public RoundFilterAttribute()
			: this("roundId", "quizId")
		{

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="RoundFilterAttribute"/> class.
		/// </summary>
		/// <param name="routeKey">Key from the route that maps to the round id.</param>
		/// <param name="quizKey">Key from the route that maps to the quiz id.</param>
		public RoundFilterAttribute(string routeKey, string quizKey)
			: base(routeKey)
		{
			this.QuizKey = quizKey;
		}

		public string QuizKey { get; }

		protected override bool EntityExists(ActionExecutingContext context, IDatabaseContext databaseContext, Guid routeValue)
		{
			var (success, quizId) = this.TryGetRouteGuidValue(context, this.QuizKey);
			if (!success)
			{
				return false;
			}

			IQueryable<Round> query = databaseContext.Rounds.Where(q => q.Guid == routeValue && q.Quiz.Guid == quizId);

			return query.Any();
		}
	}
}
