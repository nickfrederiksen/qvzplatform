using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QVZ.DAL.Entities;
using QVZ.DAL.Entities.Abstracts;
using QVZ.DAL.Entities.ReferenceTables;

namespace QVZ.DAL
{
	internal class DatabaseContext : DbContext, IEditableDatabaseContext, IDatabaseContext
	{
		public DatabaseContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<User> Users { get; set; }

		public DbSet<Dashboard> Dashboards { get; set; }

		public DbSet<Organization> Organizations { get; set; }

		public DbSet<OrganizationUserReference> OrganizationUserReferences { get; set; }

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
			SetUpdateableEntityDefaults<User>(modelBuilder);

			var dashboardEntity = SetUserManagedEntityDefaults<Dashboard>(modelBuilder);
			dashboardEntity.HasOne(e => e.User).WithMany().OnDelete(DeleteBehavior.Cascade);
			dashboardEntity.HasIndex(e => new { e.UserId, e.Name }).IsUnique(true);

			this.SetUserManagedEntityDefaults<Organization>(modelBuilder);

			var organizationUserReferenceEntity = modelBuilder.Entity<OrganizationUserReference>();
			organizationUserReferenceEntity.HasKey(r => new { r.UserId, r.OrganizationId });
			organizationUserReferenceEntity.HasOne(r => r.Organization).WithMany(o => o.UserReferences).OnDelete(DeleteBehavior.Cascade);
			organizationUserReferenceEntity.HasOne(r => r.User).WithMany().OnDelete(DeleteBehavior.Cascade);
		}

		private EntityTypeBuilder<TEntity> SetUserManagedEntityDefaults<TEntity>(ModelBuilder modelBuilder)
			where TEntity : UserManagedEntity
		{
			var entity = this.SetUpdateableEntityDefaults<TEntity>(modelBuilder);
			entity.HasOne(e => e.UserCreatedBy).WithMany().OnDelete(DeleteBehavior.Restrict);
			entity.HasOne(e => e.UserUpdatedBy).WithMany().OnDelete(DeleteBehavior.Restrict);

			return entity;
		}

		private EntityTypeBuilder<TEntity> SetUpdateableEntityDefaults<TEntity>(ModelBuilder modelBuilder)
			where TEntity : UpdateableEntity
		{
			var entity = this.SetEntityDefaults<TEntity>(modelBuilder); ;
			entity.Property(p => p.CreatedDate).ValueGeneratedOnAdd().HasDefaultValueSql("GETUTCDATE()");
			entity.Property(p => p.UpdatedDate).ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("GETUTCDATE()");

			return entity;
		}

		private EntityTypeBuilder<TEntity> SetEntityDefaults<TEntity>(ModelBuilder modelBuilder)
			where TEntity : Entity
		{
			var entity = modelBuilder.Entity<TEntity>();
			entity.Property(p => p.Guid).ValueGeneratedOnAdd().HasDefaultValueSql("NEWSEQUENTIALID()");

			return entity;
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
