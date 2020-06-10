using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using QVZ.Api.Shared.Models;

namespace QVZ.Api.Models
{
	/// <summary>
	/// Represents a quiz.
	/// </summary>
	public class QuizModel : UserManagedModel, IUserOwnedModel
	{
		/// <summary>
		/// Gets or sets the quiz name. Must be unique for the user.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the quiz date.
		/// </summary>
		public DateTime Date { get; set; }

		/// <summary>
		/// Gets the id of the user that owns the quiz.
		/// </summary>
		[BindNever]
		public Guid? UserId { get; internal set; }
	}
}
