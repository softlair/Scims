﻿using Slair.Core.Model.Abstractions;
using System.Collections.Generic;

namespace Slair.Scims.Model.Abstractions
{
	public interface IProjectDescription<T> : IEditableModel<T>
	{
		int Category { get; set; }
		string Code { get; set; }
		string Name { get; set; }
		string Description { get; set; }
		string Notes { get; set; }

		ICollection<ITaskDescription<string>> Tasks { get; set; }
		bool ArchiveFlag { get; set; }
	}
}
