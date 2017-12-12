import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { TimesheetComponent } from './timesheet.component';

@NgModule({
  declarations: [
    TimesheetComponent
  ],
  imports: [
    FormsModule,
    HttpModule
  ],
  providers: []
})
export class TimesheetModule { }
