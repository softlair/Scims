import { Component, ViewChild, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';

import { MatTableDataSource, MatSort, MatDatepickerInputEvent } from '@angular/material';
import { TimesheetModule } from 'app/layout/timesheet/timesheet.module';
import { TimesheetService } from 'app/shared/services/timesheet.service';
import { Timesheet } from 'app/shared/models/timesheet-model';
import { Subscription } from 'rxjs/Subscription';
import { IDataTemplate } from 'app/shared/models/template-data';
import { TaskTemplate } from 'app/shared/models/template-task';
import { ProjectService } from 'app/shared/services/project.service';
import { TaskService } from 'app/shared/services/task.service';

@Component({
  selector: 'page-timesheet',
  templateUrl: './timesheet.component.html',
  styleUrls: ['./timesheet.component.css'],
  providers: [ProjectService, TaskService]
})
export class TimesheetComponent implements OnInit {
  

  displayedColumns = ['Project', 'Task', 'Subtask', 'Hours', 'Remarks', 'Actions'];
  dataSource: any;

  allProjects: IDataTemplate[];
  allTasks: TaskTemplate[];

  timesheets: Timesheet[];

  currentTimesheet: Timesheet;
  tasks: TaskTemplate[];
  subTasks: TaskTemplate[];

  mSubscription:Subscription;
  date = new FormControl({ value: new Date(), disabled: true});

  currentDate: Date;

  totalHours: number;

  /**
    * Constructor
  */
  constructor(private mTimesheetSvc: TimesheetService,
              private mProjectSvc: ProjectService,
              private mTaskSvc: TaskService){

    this.allProjects = this.mProjectSvc.getProjects();

    this.allTasks = this.mTaskSvc.getTasks();

    // initialize current timesheet
    this.resetCurrentTimesheet();

    // initialize current date
    this.currentDate = this.date.value;

    // initialize total hours rendered for the day
    this.totalHours = 0;
  }

  /**
    * Initializations
  */
  ngOnInit() {

    // subscribe to timesheet service
    this.mSubscription = this.mTimesheetSvc.timesheets
        .subscribe((timesheets) => {
          if(timesheets){
            this.timesheets = timesheets;

            this.totalHours = this.mTimesheetSvc.getTotalHours();
            // load initial table
            this.loadTable();
          }
        });

    // load table based on date
    this.onDateChanged();
  }
  
  /**
    * Deconstructor
  */
  ngOnDestroy() {
    this.mSubscription.unsubscribe();
  }
  
  /**
    * Sets selected date
  */
  onDateChanged() {

    // set current date
    this.currentDate = this.date.value;

    // id date is invalid, return
    if(!this.currentDate){
      return;
    }

    this.currentDate.setHours(0,0,0,0);

    // source changed
    this.sourceChange();
  }

  /**
    * Change source
  */
  sourceChange(): void{

    this.mTimesheetSvc.getTimesheets(this.currentDate);
    
    this.loadTable();
  }

  /**
    * Load table
  */
  loadTable(): void{
    this.dataSource = new MatTableDataSource(this.timesheets);
  }

  /**
    * On project changed
  */
  onProjectChanged(): void{
    // load project tasks
    this.tasks = this.allTasks.filter(task => task.parentId == 0 && task.projectId == this.currentTimesheet.projectId);
  }

  /**
    * On task changed
  */
  onTaskChanged(): void{
    // load task subtasks
    this.subTasks = this.allTasks.filter(task => task.parentId == this.currentTimesheet.taskId && task.projectId == this.currentTimesheet.projectId);
  }
  
  /**
    * Remove timesheet from list
    * @param iElement Timesheet to be removed.
  */
  onRemoveClick(iElement: Timesheet): void{
    
    // get timesheet from list
    let timesheet = this.timesheets.find(ts => ts.tempId == iElement.tempId);
    let index = this.timesheets.indexOf(timesheet);

    // remove from list
    this.timesheets.splice(index, 1);

    // update list
    this.mTimesheetSvc.updateTimesheets(this.timesheets);

    // reset controls to default
    this.onCancelClick();
  }

  /**
    * On editing row
    * @param iElement Timesheet to be edited.
  */
  onEditClick(iElement: Timesheet): void{
    
    // set selected timesheet project
    this.currentTimesheet.projectId = iElement.projectId;
    this.onProjectChanged();

    // set selected timesheet task
    this.currentTimesheet.taskId = iElement.taskId;
    this.onTaskChanged();

    // set selected timesheet subtask
    this.currentTimesheet.subTaskId = iElement.subTaskId;

    // set selected timesheet others
    this.currentTimesheet = {
      id:iElement.id,
      tempId:iElement.tempId,
      date:iElement.date,
      isEdited:true,
      projectId:iElement.projectId,
      taskId:iElement.taskId,
      subTaskId:iElement.subTaskId,
      remarks:iElement.remarks,
      hours:iElement.hours
    };

  }
  
  /**
    * On update list
  */
  onAddClick(): void{

    // if adding
    if(this.currentTimesheet.tempId == -1){

      // get max temporary id
      let maxTempId = +Math.max.apply(Math,this.timesheets.map((o) => {return o.tempId;}));

      // check if number is infinite
      if (maxTempId == Number.POSITIVE_INFINITY || maxTempId == Number.NEGATIVE_INFINITY){
        maxTempId = 1;
      }

      // push to list
      this.timesheets.push({
        id: this.currentTimesheet.id,
        tempId: maxTempId += 1, 
        projectId: this.currentTimesheet.projectId,
        taskId: this.currentTimesheet.taskId,
        subTaskId: this.currentTimesheet.subTaskId,
        remarks: this.currentTimesheet.remarks,
        hours: this.currentTimesheet.hours,
        date: this.currentDate,
        isEdited: false
      });

    }
    else { // if editing

      // get current timesheet
      let timesheet = this.timesheets.find(ts => ts.tempId == this.currentTimesheet.tempId);
      let index = this.timesheets.indexOf(timesheet);
      
      // update timesheet based on user input
      timesheet.projectId = this.currentTimesheet.projectId;
      timesheet.taskId = this.currentTimesheet.taskId;
      timesheet.subTaskId = this.currentTimesheet.subTaskId;
      timesheet.remarks = this.currentTimesheet.remarks;
      timesheet.hours = this.currentTimesheet.hours;

      // update list
      this.timesheets[index] = timesheet;
    }

    // update timesheet list
    this.mTimesheetSvc.updateTimesheets(this.timesheets);
    
    // reset
    this.onCancelClick();
  }

  /**
    * On cancel
  */
  onCancelClick(): void{
    this.resetCurrentTimesheet();
  }

  /**
    * Reset current timesheet
  */
  resetCurrentTimesheet(): void{
    this.currentTimesheet = {
      id: '0',
      tempId: -1,
      date: this.currentDate,
      isEdited: false,
      projectId: 0,
      taskId: 0,
      subTaskId: 0,
      remarks: '',
      hours: 0
    };
  }

  /**
    * Convert id to name
    * @param iElementId Project id
  */
  getProjectHeader(iElementId: number): string {
    
    // find project by id
    let project = this.allProjects.find(project => project.id == iElementId);

    // return name if found
    if(project){
      return project.name;
    }
    
    return 'None';
  }
  
  /**
    * Convert id to name
    * @param iElementId Task id
  */
  getTaskHeader(iElementId: number): string {

    // find task by id
    let task = this.allTasks.find(task => task.id == iElementId);

    // return name if found
    if(task){
      return task.name;
    }
    
    return 'None';
  }
  
}