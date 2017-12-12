import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';

import { Headers, Http, Response, RequestOptions, RequestMethod } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/toPromise';

import { TaskTemplate } from 'app/shared/models/template-task';

@Injectable()
export class TaskService {

    private apiUrl: string;

    constructor(private http: Http){
    }

    /**
        * Return tasks
    */
    getTasks(): TaskTemplate[]{

        // TODO : convert to observable api call
        
        let TASK_DATA: TaskTemplate[] = [
          {id: 100, projectId: 100, name: 'Common', parentId: 0},
          {id: 101, projectId: 100, name: 'Others', parentId: 0},
          {id: 102, projectId: 100, name: 'PM', parentId: 100},
          {id: 103, projectId: 100, name: 'DEV', parentId: 101},
          {id: 104, projectId: 100, name: 'Testing', parentId: 101},
          {id: 105, projectId: 100, name: 'QA', parentId: 101},
          {id: 106, projectId: 101, name: 'Delivery', parentId: 0},
          {id: 107, projectId: 102, name: 'Fixing', parentId: 0}
        ];

        return TASK_DATA;
    }
}