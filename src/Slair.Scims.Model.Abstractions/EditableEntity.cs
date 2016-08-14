using System;

namespace Slair.Scims.Model.Abstractions
{
	//T: Entity data type
	//U: User ID data type
	public abstract class EditableEntity<T, U> : Entity<T>, IEditableEntity<T, U>
	{
		public DateTime CreatedDate { get; set; }
		public U CreatedBy { get; set; }

		public DateTime UpdatedDate { get; set; }
		public U UpdatedBy { get; set; }
	}
}
