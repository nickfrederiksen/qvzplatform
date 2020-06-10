using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using QVZ.DAL.Entities;
using QVZ.DAL.Entities.Interfaces;

namespace QVZ.DAL
{
	public static class DatabaseContextExtensions
	{
		public static IQueryable<TEntity> GetUserQuery<TEntity>(this IDatabaseContext databaseContext, ClaimsPrincipal user)
			where TEntity : class, IUserOwned
		{
			return GetUserQuery(databaseContext.Set<TEntity>(), user);
		}

		public static IQueryable<TEntity> GetUserQuery<TEntity>(this IQueryable<TEntity> query, ClaimsPrincipal user)
			where TEntity : class, IUserOwned
		{
			var userId = user.GetObjectIdentifier();
			return query.Where(e => e.User.ObjectId == userId).Include(u => u.User);
		}

		public static User GetUserReference(this IDatabaseContext databaseContext, ClaimsPrincipal principal)
		{
			var userId = principal.GetObjectIdentifier();

			var user = databaseContext.GetUserReference(userId);

			return user;
		}

		public static User GetUserReference(this IDatabaseContext databaseContext, Guid id)
		{
			var user = databaseContext.Users.SingleOrDefault(u => u.Guid == id);

			return user;
		}

		public static int SaveChanges(this IEditableDatabaseContext databaseContext, ClaimsPrincipal user)
		{
			var userId = user.GetObjectIdentifier();
			return databaseContext.SaveChanges(userId);
		}
	}
}
