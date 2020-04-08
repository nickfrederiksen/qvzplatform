using Microsoft.AspNetCore.Routing;
using QVZ.Api.BusinessLogic.ActionFilters.Abstracts;
using QVZ.DAL;
using System;
using System.Linq;

namespace QVZ.Api.BusinessLogic.ActionFilters
{
	internal class DashboardFilterAttribute : EntityFilterAttribute
	{
		public DashboardFilterAttribute()
			: base("dashboardId")
		{
		}

		public DashboardFilterAttribute(string routeKey)
			: base(routeKey)
		{
		}

		protected override bool EntityExists(RouteValueDictionary routeValues, IDatabaseContext databaseContext, Guid routeValue)
		{
			return databaseContext.Dashboards.Any(i => i.Guid == routeValue);
		}
	}
}
