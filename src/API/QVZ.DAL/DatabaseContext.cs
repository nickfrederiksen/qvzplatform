using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QVZ.DAL.Entities;
using QVZ.DAL.Entities.Abstracts;
using QVZ.DAL.Entities.Dashboards;
using QVZ.DAL.Entities.Interfaces;
using QVZ.DAL.Entities.Quizes;
using QVZ.DAL.Entities.ReferenceTables;

namespace QVZ.DAL
{
	internal partial class DatabaseContext : DbContext, IEditableDatabaseContext, IDatabaseContext
	{
		public DatabaseContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<User> Users { get; set; }

		public DbSet<Dashboard> Dashboards { get; set; }

		public DbSet<Organization> Organizations { get; set; }

		public DbSet<OrganizationUserReference> OrganizationUserReferences { get; set; }

		public DbSet<DashboardPanel> DashboardPanels { get; set; }

		public DbSet<DashboardPanelType> DashboardPanelTypes { get; set; }

		public DbSet<Answer> Answers { get; set; }

		public DbSet<Question> Questions { get; set; }

		public DbSet<QuestionType> QuestionTypes { get; set; }

		public DbSet<Quiz> Quizes { get; set; }

		public DbSet<Round> Rounds { get; set; }

		public DbSet<QuizOrganizationReference> QuizOrganizationReferences { get; set; }

		public int SaveChanges(string userObjectId)
		{
			User user = GetUserReference(userObjectId);

			var entries = this.ChangeTracker.Entries()
				.Where(e => e.Entity is UpdateableEntity || e.Entity is UserManagedEntity)
				.Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

			foreach (var entry in entries)
			{
				var entity = entry.Entity;
				this.SetUserReferences(user, entry, entity);
				this.SetDates(entry, entity);
			}

			return this.SaveChanges();
		}

		public User GetUserReference(string userObjectId)
		{
			// First try to find the user in the local collection, then in the DB:
			var user = this.Users.Local.SingleOrDefault(u => u.ObjectId == userObjectId) ?? this.Users.SingleOrDefault(u => u.ObjectId == userObjectId);
			if (user == null)
			{
				user = new User()
				{
					ObjectId = userObjectId,
				};
			}

			return user;
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			SetupReferenceEntities(modelBuilder);

			SetupOrganizationalEntities(modelBuilder);
			SetupDashboardEntities(modelBuilder);
			SetupQuizEntities(modelBuilder);
		}

		private void SetDates(EntityEntry entry, object entity)
		{
			if (entity is UpdateableEntity updateableEntity)
			{
				updateableEntity.UpdatedDate = DateTime.UtcNow;
				if (entry.State == EntityState.Added)
				{
					updateableEntity.CreatedDate = updateableEntity.UpdatedDate;
				}
			}
		}

		private void SetUserReferences(User user, EntityEntry entry, object entity)
		{
			if (entity is UserManagedEntity userManagedEntity)
			{
				userManagedEntity.UserUpdatedBy = user;
				if (entry.State == EntityState.Added)
				{
					userManagedEntity.UserCreatedBy = userManagedEntity.UserUpdatedBy;
				}
			}
		}
	}
}
