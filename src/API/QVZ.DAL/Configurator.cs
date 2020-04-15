using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace QVZ.DAL
{
	public static class Configurator
	{
		public static IServiceCollection AddDatabaseContext(this IServiceCollection services, string connectionString)
		{
			services.AddDbContext<IEditableDatabaseContext, DatabaseContext>(options =>
			{
				options.UseSqlServer(connectionString);
			});

			services.AddTransient<IDatabaseContext>((provider) => provider.GetRequiredService<IEditableDatabaseContext>());

			return services;
		}
	}
}
