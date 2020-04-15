﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using QVZ.DAL;
using System;

namespace QVZ.Api.BusinessLogic.ActionFilters.Abstracts
{
	internal abstract class EntityFilterAttribute : ActionFilterAttribute
	{
		public EntityFilterAttribute(string routeKey)
		{
			this.RouteKey = routeKey;
		}

		public string RouteKey { get; set; }

		public override void OnActionExecuting(ActionExecutingContext context)
		{
			var (success, value) = this.TryGetRouteValue(context.RouteData.Values, this.RouteKey);
			if (success)
			{
				var dbContext = context.HttpContext.RequestServices.GetRequiredService<IDatabaseContext>();
				var exists = this.EntityExists(context.RouteData.Values, dbContext, value);
				if (!exists)
				{
					context.Result = new NotFoundResult();
				}
			}

			base.OnActionExecuting(context);
		}

		protected abstract bool EntityExists(RouteValueDictionary routeValues, IDatabaseContext databaseContext, Guid routeValue);

		protected virtual (bool success, Guid value) TryGetRouteValue(RouteValueDictionary routeValues, string key)
		{
			Guid routeValue = default;
			var success = routeValues.TryGetValue(key, out var keyNumberIdValue) && Guid.TryParse(keyNumberIdValue as string, out routeValue);

			return (success, routeValue);
		}
	}
}