using System;
using System.Linq;
using System.Security.Claims;
using QVZ.DAL.Entities;
using QVZ.DAL.Entities.Interfaces;

namespace QVZ.DAL
{
	internal static class DatabaseContextExtensions
	{
		public static IQueryable<TEntity> GetUserQuery<TEntity>(this IDatabaseContext databaseContext, ClaimsPrincipal user)
			where TEntity : class, IUserOwned
		{
			var userId = user.GetObjectIdentifier();
			return databaseContext.Set<TEntity>().Where(e => e.User.ObjectId == userId);
		}

		public static User GetUser(this IDatabaseContext databaseContext, ClaimsPrincipal principal)
		{
			var userId = principal.GetObjectIdentifier();

			var user = databaseContext.Users.SingleOrDefault(u => u.ObjectId == userId);
			if (user == null)
			{
				user = new User()
				{
					ObjectId = userId,
				};
				databaseContext.Users.Add(user);
			}

			return user;
		}

		public static int SaveChanges(this IEditableDatabaseContext databaseContext, ClaimsPrincipal user)
		{
			var userId = user.GetObjectIdentifier();
			return databaseContext.SaveChanges(userId);
		}
	}
}
