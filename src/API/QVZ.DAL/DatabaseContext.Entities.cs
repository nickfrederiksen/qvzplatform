using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QVZ.DAL.Entities;
using QVZ.DAL.Entities.Abstracts;
using QVZ.DAL.Entities.Dashboards;
using QVZ.DAL.Entities.Interfaces;
using QVZ.DAL.Entities.Quizes;
using QVZ.DAL.Entities.ReferenceTables;

namespace QVZ.DAL
{
	internal partial class DatabaseContext
	{
		private void SetupReferenceEntities(ModelBuilder modelBuilder)
		{
			var organizationUserReferenceEntity = modelBuilder.Entity<OrganizationUserReference>();
			organizationUserReferenceEntity.HasKey(r => new { r.UserId, r.OrganizationId });
			organizationUserReferenceEntity.HasOne(r => r.Organization).WithMany(o => o.UserReferences).OnDelete(DeleteBehavior.Cascade);
			organizationUserReferenceEntity.HasOne(r => r.User).WithMany().OnDelete(DeleteBehavior.Cascade);
		}

		private void SetupOrganizationalEntities(ModelBuilder modelBuilder)
		{
			this.SetUpdateableEntityDefaults<User>(modelBuilder);

			this.SetUserManagedEntityDefaults<Organization>(modelBuilder);
		}

		private void SetupDashboardEntities(ModelBuilder modelBuilder)
		{
			var dashboardEntity = this.SetUserManagedEntityDefaults<Dashboard>(modelBuilder);
			this.SetUserOwnedDefaults(dashboardEntity);

			dashboardEntity.HasIndex(e => new { e.UserId, e.Name }).IsUnique(true);

			var panelEntity = this.SetUpdateableEntityDefaults<DashboardPanel>(modelBuilder);
			panelEntity.HasOne(p => p.Position).WithOne(p => p.Panel).OnDelete(DeleteBehavior.Cascade);
			panelEntity.HasOne(p => p.Dashboard).WithMany(d => d.Panels).OnDelete(DeleteBehavior.Cascade);
			panelEntity.HasOne(p => p.Type).WithMany(d => d.Panels).OnDelete(DeleteBehavior.Cascade);

			this.SetupPanelTypes(modelBuilder);
		}

		private void SetupQuizEntities(ModelBuilder modelBuilder)
		{
			var answerEntity = this.SetUserManagedEntityDefaults<Answer>(modelBuilder);
			answerEntity.HasOne(a => a.Organization).WithMany(o => o.Answers).OnDelete(DeleteBehavior.Cascade);
			answerEntity.HasOne(a => a.Question).WithMany(o => o.Answers).OnDelete(DeleteBehavior.Cascade);

			var questionEntity = this.SetUserManagedEntityDefaults<Question>(modelBuilder);
			questionEntity.HasOne(q => q.Type).WithMany(t => t.Questions).OnDelete(DeleteBehavior.Restrict);
			questionEntity.HasOne(q => q.Round).WithMany(t => t.Questions).OnDelete(DeleteBehavior.Cascade);

			this.SetEntityDefaults<QuestionType>(modelBuilder)
				.HasMany(e => e.Questions).WithOne(q => q.Type).OnDelete(DeleteBehavior.Restrict);

			var userEntity = this.SetUserManagedEntityDefaults<Quiz>(modelBuilder);
			this.SetUserOwnedDefaults(userEntity);

			var roundEntity = this.SetUserManagedEntityDefaults<Round>(modelBuilder);
			roundEntity.HasOne(r => r.Quiz).WithMany(q => q.Rounds).OnDelete(DeleteBehavior.Cascade);
		}


		private void SetupPanelTypes(ModelBuilder modelBuilder)
		{
			var panelTypeEntity = SetUpdateableEntityDefaults<DashboardPanelType>(modelBuilder);

			DateTime utcNow = DateTime.UtcNow;
			panelTypeEntity.HasData(
				new DashboardPanelType()
				{
					Id = 1,
					CreatedDate = utcNow,
					UpdatedDate = utcNow,
					Guid = new Guid("89dbc8b3-3c47-4734-a45d-ae6348982fd5"),
					Name = "Organizations"
				},
				new DashboardPanelType()
				{
					Id = 2,
					CreatedDate = utcNow,
					UpdatedDate = utcNow,
					Guid = new Guid("daa76c7a-02a4-4d4e-8f31-491cf850b996"),
					Name = "Users"
				});
		}

		private EntityTypeBuilder<TEntity> SetUserManagedEntityDefaults<TEntity>(ModelBuilder modelBuilder)
			where TEntity : UserManagedEntity
		{
			var entity = this.SetUpdateableEntityDefaults<TEntity>(modelBuilder);
			entity.HasOne(e => e.CreatedBy).WithMany().OnDelete(DeleteBehavior.Restrict);
			entity.HasOne(e => e.UpdatedBy).WithMany().OnDelete(DeleteBehavior.Restrict);

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

		private EntityTypeBuilder<TEntity> SetUserOwnedDefaults<TEntity>(EntityTypeBuilder<TEntity> entity)
			where TEntity : class, IUserOwned
		{
			entity.HasOne(e => e.User).WithMany().OnDelete(DeleteBehavior.Cascade);

			return entity;
		}
	}
}
