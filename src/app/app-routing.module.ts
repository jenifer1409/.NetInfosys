import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { VehiclelistComponent } from './vehiclelist/vehiclelist.component';
import { VehicleaddComponent } from './vehicleadd/vehicleadd.component';
import { VehiclechangeComponent } from './vehiclechange/vehiclechange.component';

const routes: Routes = [
  {path:'vlist',component:VehiclelistComponent},
  {path:'addvehicle',component:VehicleaddComponent},
  {path:'editvehicle/:regId',component: VehiclechangeComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
