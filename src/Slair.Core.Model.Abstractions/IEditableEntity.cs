using System;

namespace Slair.Core.Model.Abstractions
{
	public interface IEditableEntity<T> : IEntity
	{
		DateTime CreatedDate { get; set; }
		T CreatedBy { get; set; } // Creator can be an Id linked to other DB (or can be email/username)

		DateTime UpdatedDate { get; set; }
		T UpdatedBy { get; set; } // Updated can be an Id linked to other DB (or can be email/username)

	}
}
