import { inject, Injectable } from '@angular/core';
import { Team } from '../models/team.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TeamService {

  
  private url = 'https://localhost:7279/api/Team';

  http = inject(HttpClient);

  getTeams(): Observable<Team[]>
  {
    return this.http.get<Team[]>(this.url);
  }
}
