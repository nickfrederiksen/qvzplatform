using AutoMapper;
using Microsoft.AspNetCore.Http;
using QVZ.Api.Admin.Models;
using QVZ.DAL;
using QVZ.DAL.Entities;

namespace QVZ.Api.Admin.AutomapperProfiles.ValueResolvers
{
	public class UserValueResolver : IValueResolver<DashboardModel, Dashboard, User>
	{
		private readonly IHttpContextAccessor httpContextAccessor;
		private readonly IDatabaseContext databaseContext;

		public UserValueResolver(
			IHttpContextAccessor httpContextAccessor,
			IDatabaseContext databaseContext)
		{
			this.httpContextAccessor = httpContextAccessor;
			this.databaseContext = databaseContext;
		}

		public User Resolve(DashboardModel source, Dashboard destination, User destMember, ResolutionContext context)
		{
			var httpContext = this.httpContextAccessor.HttpContext;
			return this.databaseContext.GetUserReference(httpContext.User);
		}
	}
}
