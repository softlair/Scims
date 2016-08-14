using Slair.Scims.Model.Abstractions;
using System.Collections.Generic;
using System;

namespace Slair.Scims.Model
{
	public class ProjectDescription : EditableEntity<int, int>, IProjectDescription<int, int>
	{
		public ProjectDescription()
		{
			ArchiveFlag = false;
		}


		public int Category { get; set; }
		public string Code { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Notes { get; set; }

		//public ICollection<TaskDescription> Tasks { get; set; }
		public bool ArchiveFlag { get; set; }

		public ICollection<ITaskDescription<int, int>> Tasks { get; set; }
	}
}
