using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QVZ.DAL;
using QVZ.DAL.Entities.Interfaces;

namespace QVZ.Api.Shared.Controllers
{
	/// <summary>
	/// Main API controller for the QVZ API's.
	/// </summary>
	/// <typeparam name="TModel">DTO model type.</typeparam>
	/// <typeparam name="TEntity">Entity type.</typeparam>
	[ApiController]
	public abstract class QVZApiController<TModel, TEntity> : ControllerBase
		   where TModel : class, new()
		   where TEntity : class
	{
		private readonly IDatabaseContext databaseContext;
		private readonly IMapper mapper;

		/// <summary>
		/// Initializes a new instance of the <see cref="QVZApiController{TModel, TEntity}"/> class.
		/// </summary>
		/// <param name="databaseContext">Instance of the database context.</param>
		/// <param name="mapper">Instance of the Automapper mapper.</param>
		public QVZApiController(IDatabaseContext databaseContext, IMapper mapper)
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

		protected TEntity UpdateEntity(TModel model, TEntity entity)
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
