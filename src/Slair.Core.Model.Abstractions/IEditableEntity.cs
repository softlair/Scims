using System;

namespace Slair.Core.Model.Abstractions
{
	public interface IEditableEntity<T, U> : IEntity<T>
	{
		DateTime CreatedDate { get; set; }
		U CreatedBy { get; set; } // Creator can be an Id linked to other DB (or can be email/username)

		DateTime UpdatedDate { get; set; }
		U UpdatedBy { get; set; } // Updated can be an Id linked to other DB (or can be email/username)

	}
}
