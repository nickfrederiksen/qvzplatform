using System.Linq;
using AutoMapper;
using QVZ.Api.Shared.Models;
using QVZ.DAL;
using QVZ.DAL.Entities;
using QVZ.DAL.Entities.Interfaces;

namespace QVZ.Api.Shared.Controllers
{
	/// <summary>
	/// Adds user queries for <see cref="IUserOwned"/> entities and <see cref="IUserOwnedModel"/> models to <see cref="QVZApiController{TModel, TEntity}"/>.
	/// </summary>
	/// <inheritdoc/>
	public abstract class QVZUserApiController<TModel, TEntity> : QVZApiController<TModel, TEntity>
		   where TModel : class, IUserOwnedModel, new()
		   where TEntity : class, IUserOwned
	{
		private readonly IDatabaseContext databaseContext;

		/// <summary>
		/// Initializes a new instance of the <see cref="QVZUserApiController{TModel, TEntity}"/> class.
		/// </summary>
		/// <inheritdoc cref="QVZApiController{TModel, TEntity}"/>
		public QVZUserApiController(IDatabaseContext databaseContext, IMapper mapper)
			: base(databaseContext, mapper)
		{
			this.databaseContext = databaseContext;
		}

		protected IQueryable<TEntity> UserQuery { get { return this.DbSet.GetUserQuery(this.User); } }

		protected User GetUser()
		{
			return this.databaseContext.GetUserReference(this.User);
		}
	}
}
