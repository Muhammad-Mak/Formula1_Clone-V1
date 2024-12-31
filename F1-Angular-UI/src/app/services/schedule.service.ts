import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Schedule } from '../models/schedule.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ScheduleService {

  private url = 'https://localhost:7279/api/Schedule';

  http = inject(HttpClient);

  getSchedules(): Observable<Schedule[]>
  {
    return this.http.get<Schedule[]>(this.url);
  }
}
