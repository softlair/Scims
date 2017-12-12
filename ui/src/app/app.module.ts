import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { AppRoutingModule } from 'app/app-routing.module';
import { AppSharedModule } from 'app/shared/app-shared.module';
import { LoginComponent } from 'app/login/login.component';
import { LayoutComponent } from 'app/layout/layout.component';
import { TimesheetComponent } from 'app/layout/timesheet/timesheet.component';
import { TimesheetService } from 'app/shared/services/timesheet.service';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    LayoutComponent,
    TimesheetComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    AppSharedModule
  ],
  providers: [TimesheetService],
  bootstrap: [AppComponent]
})
export class AppModule { }
