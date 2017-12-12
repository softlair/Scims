import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';

import { Headers, Http, Response, RequestOptions, RequestMethod } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/toPromise';
import { Timesheet } from 'app/shared/models/timesheet-model';


@Injectable()
export class TimesheetService {

    private mTimesheets = new BehaviorSubject<Timesheet[]>([]);
    timesheets = this.mTimesheets.asObservable();

    private apiUrl: string;

    constructor(private http: Http){
    }

    /**
      * Update timesheets list
      * @param iTimesheets Date basis
    */
    updateTimesheets(iTimesheets: Timesheet[]) {
        this.mTimesheets.next(iTimesheets);
    }

    /**
      * Return total rendered hours for the day
    */
    getTotalHours(): number{
        let hoursArr = this.mTimesheets.value.map(ts => { return ts.hours; });

        return hoursArr.reduce((a, b) => a + b, 0);
    }

    /**
      * Return timesheets
      * @param iDate Date basis
    */
    getTimesheets(iDate: Date): void{

        // TODO : replace with query
        let ELEMENT_DATA: Timesheet[] = [
          {id: '1',projectId: 100,taskId: 100,subTaskId: 102,tempId: 1, remarks: 'Hydrogen1',hours: 1.0079, date: new Date('12/12/2017'), isEdited: false},
          {id: '2',projectId: 100,taskId: 100,subTaskId: 102,tempId: 2, remarks: 'Hydrogen2',hours: 1.0079, date: new Date('12/12/2017'), isEdited: false},
          {id: '3',projectId: 100,taskId: 100,subTaskId: 102,tempId: 3, remarks: 'Hydrogen3',hours: 1.0079, date: new Date('12/12/2017'), isEdited: false},
          {id: '4',projectId: 100,taskId: 100,subTaskId: 102,tempId: 4, remarks: 'Hydrogen',hours: 1.0079, date: new Date('12/10/2017'), isEdited: false},
          {id: '5',projectId: 100,taskId: 100,subTaskId: 102,tempId: 5, remarks: 'Hydrogen',hours: 1.0079, date: new Date('12/10/2017'), isEdited: false},
          {id: '6',projectId: 100,taskId: 100,subTaskId: 102,tempId: 6, remarks: 'Hydrogen',hours: 1.0079, date: new Date('12/10/2017'), isEdited: false},
          {id: '7',projectId: 100,taskId: 100,subTaskId: 102,tempId: 7, remarks: 'Hydrogen',hours: 1.0079, date: new Date('12/10/2017'), isEdited: false},
          {id: '8',projectId: 100,taskId: 100,subTaskId: 102,tempId: 8, remarks: 'Hydrogen',hours: 1.0079, date: new Date('12/09/2017'), isEdited: false},
          {id: '9',projectId: 100,taskId: 100,subTaskId: 102,tempId: 9, remarks: 'Hydrogen',hours: 1.0079, date: new Date('12/09/2017'), isEdited: false},
          {id: '10',projectId: 100,taskId: 100,subTaskId: 102,tempId: 10, remarks: 'Hydrogen',hours: 1.0079, date: new Date('12/09/2017'), isEdited: false}
        ];

        // just to make sure
        iDate.setHours(0, 0, 0, 0);

        this.updateTimesheets(ELEMENT_DATA.filter(data => data.date.toISOString() == iDate.toISOString()));
    }
}