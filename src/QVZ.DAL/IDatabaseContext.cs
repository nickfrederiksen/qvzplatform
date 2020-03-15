using Microsoft.EntityFrameworkCore;
using QVZ.DAL.Entities;

namespace QVZ.DAL
{
	public interface IDatabaseContext
	{
		DbSet<TEntity> Set<TEntity>()
			where TEntity : class;

		DbSet<User> Users { get; }

		DbSet<Dashboard> Dashboards { get; }
	}
}
