import { Component, OnInit } from '@angular/core';
import { VehicleService } from '../vehicle.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Vehicle } from '../vehicle';

@Component({
  selector: 'app-vehiclechange',
  templateUrl: './vehiclechange.component.html',
  styleUrl: './vehiclechange.component.css'
})
export class VehiclechangeComponent implements OnInit {

  editVehicleRequest:Vehicle={
    regId:'',
    vehicleId:'',
    model:'',
    lastServiceDate:new Date
};

constructor(private vehicleService:VehicleService,private router:Router,private route:ActivatedRoute){}

ngOnInit(): void {


  this.route.paramMap.subscribe({
    next: (params) => {
      const id = params.get('regId');
      console.log('Retrieved id:', id); // Debugging line
      if (id) {
        this.vehicleService.getByIdVehicle(id).subscribe({
          next: (vehicle) => {
            this.editVehicleRequest = vehicle;
            console.log('Vehicle:', vehicle);
          },
          error: (err) => {
            console.error('Error fetching vehicle:', err);
          }
        });
      } 
    },
   
  });
}

EditVehicle()
{
  this.vehicleService.editVehicle(this.editVehicleRequest.regId,this.editVehicleRequest)
  .subscribe({
    next:(response)=>
    {
      this.router.navigate(['vlist']);
      console.log(response);
    },
    error:(response)=>
    {
      console.log(response);
    }
  })
}

deleteVehicle(id:string)
{
   this.vehicleService.deleteVehicle(id)
   .subscribe({
    next:(response)=>
    {
      this.router.navigate(['vlist']);
    },
    error:(response)=>
    {
      console.log(response);''
    }
   })
}

}