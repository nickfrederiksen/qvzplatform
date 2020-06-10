using System;
using Microsoft.EntityFrameworkCore;
using QVZ.DAL.Entities;
using QVZ.DAL.Entities.Dashboards;
using QVZ.DAL.Entities.Quizes;
using QVZ.DAL.Entities.ReferenceTables;

namespace QVZ.DAL
{
	public interface IDatabaseContext
	{
		DbSet<User> Users { get; }

		DbSet<Dashboard> Dashboards { get; }

		DbSet<Organization> Organizations { get; }

		DbSet<OrganizationUserReference> OrganizationUserReferences { get; }

		DbSet<DashboardPanel> DashboardPanels { get; }

		DbSet<DashboardPanelType> DashboardPanelTypes { get; }

		DbSet<Answer> Answers { get; set; }

		DbSet<Question> Questions { get; set; }

		DbSet<QuestionType> QuestionTypes { get; set; }

		DbSet<Quiz> Quizes { get; set; }

		DbSet<Round> Rounds { get; set; }

		DbSet<TEntity> Set<TEntity>()
			where TEntity : class;

		User GetUserReference(string userObjectId);
	}
}
