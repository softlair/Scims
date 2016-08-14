using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Slair.Scims.Model.Abstractions
{
	public  interface IDailyTasksRecord<T, U> : IEditableEntity<T, U>
	{
		 DateTime Date { get; set; }
		 int Shift { get; set; }
		 DateTime StartTime { get; set; }
		 DateTime EndTime { get; set; }
		 decimal PlanWork { get; set; }
		 decimal Work { get; set; }
		 decimal PlanOvertime { get; set; }
		 decimal Overtime { get; set; }
		 decimal PaidBreak { get; set; }
		 decimal MealBreak { get; set; }
		 ICollection<ITaskInfo> Tasks { get; set; }
		//true: temporary save
		//this will allow our user to temporarily save their tasks anytime
		 bool StatusFlag { get; set; }
	}
}
