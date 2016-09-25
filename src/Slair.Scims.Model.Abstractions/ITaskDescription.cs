using Slair.Core.Model.Abstractions;
using Slair.Scims.Model.Abstractions;
using System.Collections.Generic;

namespace Slair.Scims.Model.Abstractions
{
	public interface ITaskDescription<T> : IEditableEntity<T>, IArchiveableEntity
	{

		int Category { get; set; }
		string Code { get; set; }
		string Name { get; set; }
		string Description { get; set; }
		string Notes { get; set; }
		ICollection<ITaskDescription<T>> SubTasks { get; set; }
		ICollection<IProjectDescription<T>> Projects { get; set; }
	}
}