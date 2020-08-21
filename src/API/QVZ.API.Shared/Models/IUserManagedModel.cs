using System;

namespace QVZ.Api.Shared.Models
{
	public interface IUserManagedModel : IUpdateableModel
	{
		Guid CreatedById { get; }
		Guid UpdatedById { get; }
	}
}