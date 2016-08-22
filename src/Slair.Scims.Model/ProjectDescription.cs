﻿using Slair.Core.Model.Abstractions;
using Slair.Scims.Model.Abstractions;
using System.Collections.Generic;
using System;

namespace Slair.Scims.Model
{
	public class ProjectDescription : EditableEntityBase<string>, IProjectDescription<string>
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

		public bool ArchiveFlag { get; set; }


		public ICollection<ITaskDescription<string>> Tasks { get; set; }
	}
}
