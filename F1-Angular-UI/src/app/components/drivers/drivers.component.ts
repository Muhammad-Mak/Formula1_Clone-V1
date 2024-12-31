import { Component, inject, OnInit } from '@angular/core';
import { Driver } from '../../models/driver.model';
import { DriverService } from '../../services/driver.service';
import { NgFor, NgIf, CommonModule, AsyncPipe } from '@angular/common';


@Component({
  selector: 'app-drivers',
  standalone: true,
  imports: [NgFor,NgIf,CommonModule,AsyncPipe],
  templateUrl: './drivers.component.html',
  styleUrl: './drivers.component.scss'
})
export default class DriversComponent implements OnInit{
  drivers: Driver[] = [];
  selectedDriver: Driver | null = null;

  driverService = inject(DriverService);

  ngOnInit(): void {
    this.driverService.getDrivers().subscribe((data: Driver[]) => {
      this.drivers = data;
      console.log('Drivers fetched:', this.drivers);
    }, error => {
      console.error('Error fetching drivers',error)
    });
  }

  selectDriver(driver: Driver): void{
    //if currently selected is same as the driver that was just clicked on
    if (this.selectedDriver === driver){
      this.selectedDriver = null;
    }else{
      this.selectedDriver = driver;
      const bottomElement = document.getElementById('bottom');
      if(bottomElement){
        bottomElement.scrollIntoView({ behavior : 'smooth' });
      }
    }
   
  }
}
