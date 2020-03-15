using Microsoft.EntityFrameworkCore;
using QVZ.DAL.Entities;

namespace QVZ.DAL
{
	public interface IDatabaseContext
	{
		DbSet<User> Users { get; }

		DbSet<Dashboard> Dashboards { get; }
	}
}
