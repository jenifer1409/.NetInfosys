import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { VehiclelistComponent } from './vehiclelist/vehiclelist.component';
import { VehicleaddComponent } from './vehicleadd/vehicleadd.component';
import { VehiclechangeComponent } from './vehiclechange/vehiclechange.component';
import { VehicleService } from './vehicle.service';
import { HttpClient, provideHttpClient } from '@angular/common/http';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    VehiclelistComponent,
    VehicleaddComponent,
    VehiclechangeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule
    
  ],
  providers: [VehicleService,provideHttpClient()],
  bootstrap: [AppComponent]
})
export class AppModule { }
