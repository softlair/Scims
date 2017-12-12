import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from 'app/login/login.component';
import { LayoutComponent } from 'app/layout/layout.component';
import { TimesheetComponent } from 'app/layout/timesheet/timesheet.component';

const routes: Routes = [
    { path: 'login', component: LoginComponent },
    { 
        path: 'layout', 
        component: LayoutComponent,
        children: [
            {
                path: '',
                component: TimesheetComponent
            }
        ] 
    },
    { path: '**', redirectTo: 'login' }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }