import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Driver } from '../models/driver.model';


@Injectable({
  providedIn: 'root'
})
export class DriverService {

  private url = 'https://localhost:7279/api/Driver';

  http = inject(HttpClient);

  getDrivers(): Observable<Driver[]>
  {
    return this.http.get<Driver[]>(this.url);
  }
}
