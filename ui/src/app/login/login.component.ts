import { Component } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { LoginModel } from 'app/shared/models/login-model';
import { error } from 'util';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  loginModel: LoginModel;

  username = new FormControl('', [Validators.required]);
  password = new FormControl('', [Validators.required]);

  /**
    * Constructor
  */
  constructor(private router: Router){
    this.loginModel = new LoginModel();
  }

  /**
    * On login
  */
  onLogin(): void {
    if(!this.loginModel || 
       !this.loginModel.username || 
       !this.loginModel.password){
      return;
    }

    // TODO : call login api
    // TODO : save token

    // redirect
    this.router.navigate(['layout']);
  }

  /**
    * Return error
    * @param iFormControl Control to check
  */
  getErrorMessage(iFormControl: FormControl) {
    return iFormControl.hasError('required') ? 'You must enter a value' : '';
  }
}
