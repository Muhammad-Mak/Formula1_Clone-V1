import { AsyncPipe, CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, NgControl, ReactiveFormsModule, Validators } from '@angular/forms';
import { Posts } from '../../models/Posts.model';
import { HttpClient } from '@angular/common/http';
import { response } from 'express';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule,AsyncPipe,ReactiveFormsModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent implements OnInit{
  postForm: FormGroup;
  posts: Posts[] = [];
  fb = inject(FormBuilder);
  http = inject(HttpClient);
  username = '';

  constructor() {
    this.postForm = this.fb.group({
      postDetails: ['',Validators.required],
      username: [''],
    })
  }
  getUsername() {
    try {
      var sessionData = sessionStorage.getItem('username');
      if(sessionData) {
        this.username = JSON.parse(sessionData);
        return this.username;
      }
    } catch (error) {
    }
    return '';
  }
  ngOnInit(): void {
    this.fetchPosts();
  }

  onSubmit(): void {
    if(this.postForm.valid){
      const postData = {
        postDetails: this.postForm.value.postDetails,
        username: this.getUsername(),
      };

      this.http.post('https://localhost:7279/api/Posts', postData).subscribe(
        response => {
          console.log('Post created', response);
          this.postForm.reset();
          this.fetchPosts();
        },
        error => {
          console.error('Error creating post', error);
        }
      );
    }
  }

  fetchPosts(): void {
    this.http.get<Posts[]>('https://localhost:7279/api/Posts').subscribe(
      data => {
        this.posts = data;
      },
      error => {
        console.error('Error fetching posts', error)
      }
    );
  }
}
