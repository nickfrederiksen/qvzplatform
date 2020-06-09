using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QVZ.DAL;

namespace QVZ.API.Shared.Controllers
{
	[ApiController]
	public abstract class ApiController<TModel, TEntity> : ControllerBase
		   where TModel : class, new()
		   where TEntity : class
	{
		private readonly IDatabaseContext databaseContext;
		private readonly IMapper mapper;

		public ApiController(IDatabaseContext databaseContext, IMapper mapper)
		{
			this.DbSet = databaseContext.Set<TEntity>();
			this.databaseContext = databaseContext;
			this.mapper = mapper;
		}

		protected DbSet<TEntity> DbSet { get; }

		protected TEntity GetEntity(TModel model)
		{
			return this.mapper.Map<TEntity>(model);
		}

		protected TEntity GetEntity(TModel model, TEntity entity)
		{
			return this.mapper.Map(model, entity);
		}

		protected TModel GetModel(TEntity entity)
		{
			return this.mapper.Map<TModel>(entity);
		}

		protected IQueryable<TModel> ProjectToModel(IQueryable<TEntity> query)
		{
			return this.mapper.ProjectTo<TModel>(query);
		}
	}
}
