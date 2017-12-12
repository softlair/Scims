import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';

import { Headers, Http, Response, RequestOptions, RequestMethod } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/toPromise';

import { IDataTemplate } from 'app/shared/models/template-data';

@Injectable()
export class ProjectService {

    private apiUrl: string;

    constructor(private http: Http){
    }

    /**
        * Return projects
    */
    getProjects():IDataTemplate[]{

        // TODO : convert to observable api call
        let PROJECT_DATA: IDataTemplate[] = [
          {id: 100, name: '100-Migration-90'},
          {id: 101, name: '101-FSD-90'},
          {id: 102, name: '102-PNC-90'}
        ];

        return PROJECT_DATA;
    }
}