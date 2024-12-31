import { compileClassDebugInfo } from '@angular/compiler';
import { Component } from '@angular/core';
import { Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { SignupComponent } from './components/signup/signup.component';
import { HomeComponent } from './components/home/home.component';
import DriversComponent from './components/drivers/drivers.component';
import { ScheduleComponent } from './components/schedule/schedule.component';
import { TeamsComponent } from './components/teams/teams.component';
import { ProfileComponent } from './components/profile/profile.component';

export const routes: Routes = [
    {path:'login', component: LoginComponent},
    {path:'signup', component: SignupComponent},
    {path:'home', component: HomeComponent},
    {path:'drivers', component: DriversComponent},
    {path:'schedule', component: ScheduleComponent},
    {path:'teams', component: TeamsComponent},
    {path:'profile', component: ProfileComponent}
];
