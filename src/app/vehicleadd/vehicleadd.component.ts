import { Component,OnInit } from '@angular/core';
import { VehicleService } from '../vehicle.service';
import { Vehicle } from '../vehicle';
import { Router } from '@angular/router';

@Component({
  selector: 'app-vehicleadd',
  templateUrl: './vehicleadd.component.html',
  styleUrl: './vehicleadd.component.css'
})
export class VehicleaddComponent implements OnInit  {

  addVehicleRequest:Vehicle={
      regId:'',
      vehicleId:'',
      model:'',
      lastServiceDate:new Date
  };

  constructor(private vehicleService:VehicleService,private router:Router){}

  ngOnInit(): void {
    
  }

  addVehicleDetails()
  {
    this.vehicleService.addVehicle(this.addVehicleRequest)
    .subscribe({
      next:(vehicle)=>
      {
        this.router.navigate(['vlist']);
        console.log(vehicle);
      },
      error:(response)=>
      {
        console.log(response)
      }
    })
  }

}
