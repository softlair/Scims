using Slair.Core.Model.Abstractions;
using System;

namespace Slair.Scims.Model.Abstractions
{
	public interface IShiftDescription<T, U> : IEditableEntity<T, U>, IArchiveableEntity
	{

		string Name { get; set; }
		string Description { get; set; }
		DateTime StartTime { get; set; }
		DateTime EndTime { get; set; }
		string Notes { get; set; }
	}
}
