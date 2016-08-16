using Slair.Core.Model.Abstractions;
using Slair.Scims.Model.Abstractions;
using System;

namespace Slair.Scims.Model
{
	public class ShiftDescription : EditableEntityBase<int, int>, IShiftDescription<int, int>
	{
		public ShiftDescription ( )
		{
			ArchiveFlag = false;
		}

		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public string Notes { get; set; }
		public bool ArchiveFlag { get; set; }
	}
}
