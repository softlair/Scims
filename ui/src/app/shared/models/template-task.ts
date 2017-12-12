import { IDataTemplate } from "app/shared/models/template-data";

export class TaskTemplate implements IDataTemplate{
  id: number;
  name: string;

  projectId: number;
  parentId: number;
}