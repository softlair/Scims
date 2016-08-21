using Slair.Scims.Model.Abstractions;
using System;
using System.Collections.Generic;

namespace Slair.Scims.Model
{
	public class DailyTasksRecord: EditableModelBase<string>, IDailyTasksRecord<string>
	{
		public DailyTasksRecord ( )
		{

		}

		public DateTime Date { get; set; }
		public int Shift { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public decimal PlanWork { get; set; }
		public decimal Work { get; set; }
		public decimal PlanOvertime { get; set; }
		public decimal Overtime { get; set; }
		public decimal PaidBreak { get; set; }
		public decimal MealBreak { get; set; }
		public ICollection<ITaskInfo<string>> Tasks { get; set; }

		//true: temporary save
		//this will allow our user to temporarily save their tasks anytime
		public bool StatusFlag { get; set; }
	}
}
