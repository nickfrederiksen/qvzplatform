﻿using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QVZ.DAL.Entities;
using QVZ.DAL.Entities.Abstracts;

namespace QVZ.DAL
{
	internal class DatabaseContext : DbContext, IEditableDatabaseContext, IDatabaseContext
	{
		public DatabaseContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<User> Users { get; set; }

		public DbSet<Dashboard> Dashboards { get; set; }

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

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			SetUpdateableEntityDefaults<User>(modelBuilder);
			SetUserManagedEntityDefaults<Dashboard>(modelBuilder);
		}

		private void SetUserManagedEntityDefaults<TEntity>(ModelBuilder modelBuilder)
			where TEntity : UserManagedEntity
		{
			var entity = modelBuilder.Entity<TEntity>();
			entity.HasOne(e => e.UserCreatedBy).WithMany().OnDelete(DeleteBehavior.Restrict);
			entity.HasOne(e => e.UserUpdatedBy).WithMany().OnDelete(DeleteBehavior.Restrict);

			this.SetUpdateableEntityDefaults<TEntity>(modelBuilder);
		}

		private void SetUpdateableEntityDefaults<TEntity>(ModelBuilder modelBuilder)
			where TEntity : UpdateableEntity
		{
			var entity = modelBuilder.Entity<TEntity>();
			entity.Property(p => p.CreatedDate).ValueGeneratedOnAdd().HasDefaultValueSql("GETUTCDATE()");
			entity.Property(p => p.UpdatedDate).ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("GETUTCDATE()");

			this.SetEntityDefaults<TEntity>(modelBuilder);
		}

		private void SetEntityDefaults<TEntity>(ModelBuilder modelBuilder)
			where TEntity : Entity
		{
			var entity = modelBuilder.Entity<TEntity>();
			entity.Property(p => p.Guid).ValueGeneratedOnAdd().HasDefaultValueSql("NEWSEQUENTIALID()");
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

		private User GetUserReference(string userObjectId)
		{
			var user = this.Users.SingleOrDefault(u => u.ObjectId == userObjectId);
			if (user == null)
			{
				user = new User()
				{
					ObjectId = userObjectId,
				};

				this.Users.Add(user);
			}

			return user;
		}
	}
}
