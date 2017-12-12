export interface Timesheet {
  id: string;
  tempId: number;
  isEdited: boolean;

  projectId: number;
  taskId: number;
  subTaskId: number;
  hours: number;
  remarks: string;
  date: Date;
}