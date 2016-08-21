using System;

namespace Slair.Core.Model.Abstractions
{
	//T: Entity data type
	//U: User ID data type
	public abstract class EditableEntityBase<T> : EntityBase, IEditableEntity<T>
	{
		public DateTime CreatedDate { get; set; }
		public T CreatedBy { get; set; }

		public DateTime UpdatedDate { get; set; }
		public T UpdatedBy { get; set; }
	}
}
