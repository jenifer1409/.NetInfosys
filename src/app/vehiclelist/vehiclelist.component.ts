import { Component, OnInit } from '@angular/core';
import { VehicleService } from '../vehicle.service';
import { Vehicle } from '../vehicle';

@Component({
  selector: 'app-vehiclelist',
  templateUrl: './vehiclelist.component.html',
  styleUrl: './vehiclelist.component.css'
})
export class VehiclelistComponent implements OnInit{


  vehicles:Vehicle[]=[];
  constructor(private vehicleService:VehicleService)
  {}

  ngOnInit(): void {
    this.vehicleService.getAllVehicles()
    .subscribe({
      next:(vehicle)=>
      {
        this.vehicles=vehicle;
        console.log(this.vehicles);
      },
      error:(response)=>
      {
        console.log(response);
      }
    })
  }

}
