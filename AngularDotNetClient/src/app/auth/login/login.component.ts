import { Component } from '@angular/core';
import {FormBuilder, Validators} from '@angular/forms';
import { Router } from '@angular/router';
import { LoginRequest } from 'src/app/interfaces/login';
import Swal from 'sweetalert2'
import { AuthService } from '../../services/auth.service';
import { LoginApiResponse } from '../../interfaces/loginApiResponse';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  public LoginForm = this.form.group({
    username: ['', [Validators.required, Validators.minLength(6)]],
    password: ['', [Validators.required, Validators.minLength(6)]],
  });
  private formSubmitted: boolean = false;

  constructor(private form:FormBuilder, private router: Router, private authService: AuthService){}

  login(){
    this.formSubmitted = true;
    if(this.LoginForm.invalid){
      return;
    }
    this.authService.login(new LoginRequest(this.LoginForm.get("username")?.value || "", this.LoginForm.get("password")?.value || ""))
      .subscribe({
        next: (data: LoginApiResponse) => {
          Swal.fire({icon: 'success',title: 'Welcome!', text: `Welcome mr/ms ${data.user.name}`})
        },
        error: err =>{
          console.log(err)
          Swal.fire({icon: 'error',title: 'Error', text: err.error.message})
        }
      });
  }

  fieldNotValid(field: string): boolean{
    let exit: boolean = false; 
    if(this.LoginForm.get(field)?.invalid && this.formSubmitted){
      exit = true;
    }
    return exit;
  }
}
