import { JsonPipe, NgIf } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import ValidateForm from '../../helpers/validateform';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [RouterLink,ReactiveFormsModule,NgIf],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent implements OnInit {

  type: string = "password";
  isText: boolean = false;
  eyeIcon: string ="fa-eye-slash";
  router = inject(Router);
  //! is definite assignment op, will definitely assign a value to loginform at some point before it is used
  loginForm!: FormGroup;
  constructor(private fb: FormBuilder, private auth: AuthService) {
    if(typeof sessionStorage != 'undefined')
    if(sessionStorage.getItem('loggedin')){
      this.router.navigate(['home']);
    }
   }

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      username: ['',Validators.required],
      password: ['',Validators.required]
    })
  }

  hideshowpass(){
    this.isText = !this.isText;
    this.isText ? this.eyeIcon = "fa-eye" : this.eyeIcon = "fa-eye-slash";
    this.isText ? this.type = "text" : this.type = "password";
  }

  onLogin(){
    if(this.loginForm.valid){
      console.log(this.loginForm.valid)
      //send obj to db
      this.auth.login(this.loginForm.value).subscribe({
        next:(res=>{
          alert(res.message)
          if(res.status) {
            // login
            sessionStorage.setItem('loggedin', JSON.stringify(res.status));
            sessionStorage.setItem('userdata', JSON.stringify(res.data));
            sessionStorage.setItem('admin', JSON.stringify(res.admin));
            sessionStorage.setItem('username', JSON.stringify(res.username));
            window.location.reload();
            ///
          }
        }),
        error:(err=>{
          alert(err?.error.message)
        })
      })
    }else{
      ValidateForm.validateAllFormFields(this.loginForm);
      alert("Your form is invalid")
      //throw error with required fields
    }
  }
 
}
