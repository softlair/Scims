using Slair.Scims.Model.Abstractions;

namespace Slair.Scims.Model
{
	public class TaskInfo : EditableModelBase<string>, ITaskInfo<string>
	{ 
		public TaskInfo ( )
		{

		}

		// User ID this task is assigned to
		// Do not confuse with EditableEntity.CreatedBy
		public int UserId { get; set; }
		public int ProjectId { get; set; }
		public int TaskId { get; set; }
		public int SubTaskId { get; set; }
		public decimal PlanWork { get; set; }
		public decimal ActualWork { get; set; }
		public decimal PlanOvertime { get; set; }
		public decimal ActualOvertime { get; set; }
		public bool Planned { get; set; }
		public string Notes { get; set; }
	}
}
