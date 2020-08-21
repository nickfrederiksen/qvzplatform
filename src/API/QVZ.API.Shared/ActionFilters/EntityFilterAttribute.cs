using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using QVZ.DAL;

namespace QVZ.Api.Shared.ActionFilters
{
	public abstract class EntityFilterAttribute : ActionFilterAttribute
	{
		public EntityFilterAttribute(string routeKey)
		{
			this.RouteKey = routeKey;
		}

		public string RouteKey { get; set; }

		public override void OnActionExecuting(ActionExecutingContext context)
		{
			var (success, value) = this.TryGetRouteGuidValue(context, this.RouteKey);
			if (success)
			{
				var dbContext = context.HttpContext.RequestServices.GetRequiredService<IDatabaseContext>();
				var exists = this.EntityExists(context, dbContext, value);
				if (!exists)
				{
					context.Result = new NotFoundResult();
				}
			}

			base.OnActionExecuting(context);
		}

		protected abstract bool EntityExists(ActionExecutingContext context, IDatabaseContext databaseContext, Guid routeValue);

		protected virtual (bool success, Guid value) TryGetRouteGuidValue(ActionExecutingContext context, string key)
		{
			return this.TryGetRouteGuidValue(context.RouteData.Values, key);
		}

		protected virtual (bool success, Guid value) TryGetRouteGuidValue(RouteValueDictionary routeValues, string key)
		{
			Guid routeValue = default;
			var success = routeValues.TryGetValue(key, out var keyNumberIdValue) && Guid.TryParse(keyNumberIdValue as string, out routeValue);

			return (success, routeValue);
		}
	}
}
