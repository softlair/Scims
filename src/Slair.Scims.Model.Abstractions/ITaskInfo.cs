using Slair.Core.Model.Abstractions;

namespace Slair.Scims.Model.Abstractions
{
	 public interface ITaskInfo<T> : IEditableEntity<T>
	{

		// User ID this task is assigned to
		// Do not confuse with EditableEntity.CreatedBy
		 int UserId { get; set; }
		 int ProjectId { get; set; }
		 int TaskId { get; set; }
		 int SubTaskId { get; set; }
		 decimal PlanWork { get; set; }
		 decimal ActualWork { get; set; }
		 decimal PlanOvertime { get; set; }
		 decimal ActualOvertime { get; set; }
		 bool Planned { get; set; }
		 string Notes { get; set; }
	}
}
