using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using QVZ.Api.Shared.ActionFilters;
using QVZ.DAL;

namespace QVZ.Api.Admin.ActionFilters
{
	public class DashboardFilterAttribute : EntityFilterAttribute
	{
		public DashboardFilterAttribute()
			: base("dashboardId")
		{
		}

		public DashboardFilterAttribute(string routeKey)
			: base(routeKey)
		{
		}

		protected override bool EntityExists(ActionExecutingContext context, IDatabaseContext databaseContext, Guid routeValue)
		{
			return databaseContext.Dashboards.Any(i => i.Guid == routeValue);
		}
	}
}
