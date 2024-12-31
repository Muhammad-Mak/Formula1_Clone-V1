import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-profile',
  standalone: true,
  imports: [ReactiveFormsModule,RouterLink,CommonModule],
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.scss'
})
export class ProfileComponent implements OnInit{
  driverForm: FormGroup;
  teamForm: FormGroup;
  raceForm: FormGroup;

  fb = inject(FormBuilder);
  http = inject(HttpClient);
  private baseUrl:string ="https://localhost:7279/api/"

  constructor() {
    this.driverForm = this.fb.group({
      driverNumber: ['',Validators.required],
      driverPoints: ['',Validators.required],
      driverPosition: ['',Validators.required],
    });

    this.teamForm = this.fb.group({
      teamName: ['',Validators.required],
      teamPoints: ['',Validators.required],
      teamPosition: ['',Validators.required],
    });
    this.raceForm = this.fb.group({
      location: ['',Validators.required],
      raceDate: [''],
    });
    
  }

  ngOnInit(): void {}
  
  onUpdateDriver(){
    if(this.driverForm.valid){
      this.http.put(`https://localhost:7279/api/Driver/${this.driverForm.value.driverNumber}`,this.driverForm.value).subscribe(response =>{
        console.log('Driver updated',response);
        alert('Driver updated');
        this.driverForm.reset();
      });
    }
  }

  onUpdateTeam(){
    if(this.teamForm.valid){
      this.http.put(`https://localhost:7279/api/Team/${this.teamForm.value.teamName}`,this.teamForm.value).subscribe(response =>{
        console.log('Team updated',response);
        alert('Team updated');
        this.teamForm.reset();
      });
    }
  }

  onUpdateRace() {
    if (this.raceForm.valid) {
      this.http.put(`https://localhost:7279/api/Schedule/${this.raceForm.value.location}`, this.raceForm.value).subscribe(response => {
        console.log('Race updated', response);
        alert('Race updated');
        this.raceForm.reset();
      });
    }
  }
  onDeleteRace() {
    const raceLocationControl = this.raceForm.get('location');
    if (raceLocationControl && raceLocationControl.valid) {
      this.http.delete(`https://localhost:7279/api/Schedule/${raceLocationControl.value}`).subscribe(response => {
        console.log('Race deleted', response);
        alert('Race deleted');
        this.raceForm.reset();
      });
    } else {
      console.error('Race location is required.');
    }
  }
  

}
