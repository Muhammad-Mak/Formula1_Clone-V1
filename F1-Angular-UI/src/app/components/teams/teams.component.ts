import { Component, inject, OnInit } from '@angular/core';
import { Team } from '../../models/team.model';
import { TeamService } from '../../services/team.service';
import { AsyncPipe, CommonModule, NgFor, NgIf } from '@angular/common';

@Component({
  selector: 'app-teams',
  standalone: true,
  imports: [CommonModule,AsyncPipe,NgFor,NgIf],
  templateUrl: './teams.component.html',
  styleUrl: './teams.component.scss'
})
export class TeamsComponent implements OnInit{
  teams: Team[] = [];
  selectedTeam: Team | null = null;

  teamService = inject(TeamService);

  ngOnInit(): void {
    this.teamService.getTeams().subscribe((data: Team[]) => {
      this.teams = data;
      console.log('Team Fetched:', this.teams);
    }, error => {
      console.error('Error fetching teams',error)
    });
  }

  selectTeam(team: Team): void{
    //if currently selected is same as the team that was just clicked on
    if (this.selectedTeam === team){
      this.selectedTeam = null;
    }else{
      this.selectedTeam = team;
      const bottomElement = document.getElementById('bottom');
      if(bottomElement){
        bottomElement.scrollIntoView({ behavior : 'smooth' });
      }
    }

  }
}
