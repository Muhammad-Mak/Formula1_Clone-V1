import { Component, inject, OnInit } from '@angular/core';
import { ScheduleService } from '../../services/schedule.service';
import { Schedule } from '../../models/schedule.model';
import { AsyncPipe, CommonModule, NgFor, NgIf } from '@angular/common';

@Component({
  selector: 'app-schedule',
  standalone: true,
  imports: [CommonModule,AsyncPipe,NgFor,NgIf],
  templateUrl: './schedule.component.html',
  styleUrl: './schedule.component.scss'
})
export class ScheduleComponent implements OnInit{
  schedules: Schedule[] = [];
  selectedSchedule: Schedule | null = null;

  scheduleService = inject(ScheduleService);

  ngOnInit(): void {
    this.scheduleService.getSchedules().subscribe((data: Schedule[]) => {
      this.schedules = data;
      console.log('Schedule Fetched:', this.schedules);
    }, error => {
      console.error('Error fetching schedules',error)
    });
  }

  selectSchedule(schedule: Schedule): void{
    //if currently selected is same as the schedule that was just clicked on
    if (this.selectedSchedule === schedule){
      this.selectedSchedule = null;
    }else{
      this.selectedSchedule = schedule;
      const bottomElement = document.getElementById('bottom');
      if(bottomElement){
        bottomElement.scrollIntoView({ behavior : 'smooth' });
      }
    }

  }
}
