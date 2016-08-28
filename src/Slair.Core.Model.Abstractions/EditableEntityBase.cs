using System;

namespace Slair.Core.Model.Abstractions
{
	//T: Entity data type
	//U: User ID data type
	public abstract class EditableEntityBase<T, U> : EntityBase<T>, IEditableEntity<T, U>
	{
		public DateTime CreatedDate { get; set; }
		public U CreatedBy { get; set; }

		public DateTime UpdatedDate { get; set; }
		public U UpdatedBy { get; set; }
	}

	public abstract class EditableEntityBase<T> : EditableEntityBase<int, T>
	{
	}
}
