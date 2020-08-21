using System;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.EntityFrameworkCore;
using QVZ.DAL.Entities;
using QVZ.DAL.Entities.Abstracts;
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

			if (typeof(UserManagedEntity).IsAssignableFrom(typeof(TEntity)))
			{
				query = query
					.Include(nameof(UserManagedEntity.CreatedBy))
					.Include(nameof(UserManagedEntity.UpdatedBy));
			}

			return query
				.Where(e => e.User.ObjectId == userId)
				.Include(u => u.User);
		}

		public static IQueryable<TEntity> GetUserManagedQuery<TEntity>(this IQueryable<TEntity> query)
			where TEntity : UserManagedEntity
		{
			return query.Include(e => e.CreatedBy).Include(e => e.UpdatedBy);
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
