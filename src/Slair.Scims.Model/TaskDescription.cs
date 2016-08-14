using Slair.Scims.Model.Abstractions;
using System.Collections.Generic;

namespace Slair.Scims.Model
{
	public class TaskDescription : EditableEntity<int, int>, ITaskDescription<int, int>
	{
		public TaskDescription ( )
		{
			ArchiveFlag = false;
		}

		public int Category { get; set; }
		public string Code { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Notes { get; set; }
		public ICollection<ITaskDescription<int, int>> SubTasks { get; set; }
		public bool ArchiveFlag { get; set; }
	}
}