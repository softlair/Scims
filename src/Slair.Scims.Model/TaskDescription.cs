using Slair.Core.Model.Abstractions;
using Slair.Scims.Model.Abstractions;
using System.Collections.Generic;
using System;
using Slair.Scims.Definitions;

namespace Slair.Scims.Model
{
	public class TaskDescription : EditableEntityBase<string>, ITaskDescription<string>
	{
		public TaskDescription ( )
		{
			ArchiveFlag = false;
			Category = TaskCategory.MainTask;
		}

		public TaskCategory Category { get; set; }
		public string Code { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Notes { get; set; }
		public ICollection<ITaskDescription<string>> SubTasks { get; set; }
		public bool ArchiveFlag { get; set; }
		public ICollection<IProjectDescription<string>> Projects { get; set; }
	}
}