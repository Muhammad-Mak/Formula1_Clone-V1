import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {


  private baseUrl:string = "https://localhost:7279/api/User/"
  http = inject(HttpClient)

  signUp(userObj:any){
    return this.http.post<any>(`${this.baseUrl}signup`,userObj)

  }
  login(loginObj:any){
    return this.http.post<any>(`${this.baseUrl}login`,loginObj)
  }
}
