using System;

namespace QVZ.Api.Shared.Models
{
	public interface IUserOwnedModel
    {
		Guid? UserId { get; }
	}
}
