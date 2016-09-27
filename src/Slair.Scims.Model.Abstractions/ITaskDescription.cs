using Slair.Core.Model.Abstractions;
using Slair.Scims.Definitions;
using Slair.Scims.Model.Abstractions;
using System.Collections.Generic;

namespace Slair.Scims.Model.Abstractions
{
	public interface ITaskDescription<T> : IEditableEntity<T>, IArchiveableEntity
	{
		TaskCategory Category { get; set; }
		string Code { get; set; }
		string Name { get; set; }
		string Description { get; set; }
		string Notes { get; set; }
	}
}