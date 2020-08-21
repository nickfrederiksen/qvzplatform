using System.Collections.Generic;

namespace QVZ.Api.Shared.Models
{
	/// <summary>
	/// Key value pair of validation errors.
	/// </summary>
	public interface IBadRequestModel : IDictionary<string, IEnumerable<string>>
	{

	}
}
