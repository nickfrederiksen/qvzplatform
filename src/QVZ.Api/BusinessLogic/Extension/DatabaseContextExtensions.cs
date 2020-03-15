using System.Security.Claims;

namespace QVZ.DAL
{
	internal static class DatabaseContextExtensions
	{
		public static int SaveChanges(this IEditableDatabaseContext dbContext, ClaimsPrincipal user)
		{
			var userId = user.FindFirstValue("http://schemas.microsoft.com/identity/claims/objectidentifier");

			return dbContext.SaveChanges(userId);
		}
	}
}
