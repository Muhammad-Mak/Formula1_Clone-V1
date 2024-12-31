import { Component, inject, NgModule } from '@angular/core';
import { FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Router, RouterLink, RouterOutlet } from '@angular/router';
import { SignupComponent } from './components/signup/signup.component';
import { LoginComponent } from './components/login/login.component';
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, RouterLink, ReactiveFormsModule, FormsModule , SignupComponent, LoginComponent, CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'F1-Angular-UI';
  router = inject(Router);
  isLoggedIn = false;
  admin = false;
 

  /**
   *
   */
  constructor() {
    this.getIsLoggedIn();
    if(!this.isLoggedIn) {
      this.router.navigate(['login']);
      
    }
    this.getIsAdmin();
  }

  getIsLoggedIn() {
    try {
      var sessionData = sessionStorage.getItem('loggedin');
      if(sessionData) {
        this.isLoggedIn = JSON.parse(sessionData);
        console.log(sessionData)
      }
    } catch (error) {}
  }

  getIsAdmin() {
    try {
      var sessionData = sessionStorage.getItem('admin');
      if(sessionData) {
        this.admin = JSON.parse(sessionData);
        console.log(sessionData)
      }
    } catch (error) {}
  }

  onLogout(){
    sessionStorage.clear();
    this.router.navigate(['home']);
    window.location.reload();
  }
}