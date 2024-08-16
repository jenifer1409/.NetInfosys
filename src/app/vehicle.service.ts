import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';
import { Vehicle } from './vehicle';

@Injectable({
  providedIn: 'root'
})
export class VehicleService {

  baseUrl:string ="https://localhost:7230";

  constructor(private http:HttpClient) {}

  getAllVehicles():Observable<Vehicle[]>
  {
    return this.http.get<Vehicle[]>(this.baseUrl+'/api/Vehicle/GetAll');
  }

  getByIdVehicle(id:string):Observable<Vehicle>
  {
    const params = new HttpParams().set('id', id);
    // Make the GET request with query parameters
    return this.http.get<Vehicle>(`${this.baseUrl}/api/Vehicle/GetById`, { params }).pipe(
      catchError((error) => {
        console.error('Error in getByIdVehicle:', error);
        return throwError(() => new Error('Error fetching vehicle data'));
      })
    );
  }

  addVehicle(addvehicleRequest:Vehicle):Observable<Vehicle[]>
  {
    addvehicleRequest.regId='00000000-0000-0000-0000-000000000000';
    return this.http.post<Vehicle[]>(this.baseUrl+'/api/Vehicle/addVehicle',addvehicleRequest);
  }
  
  editVehicle(id:string,editvehicleRequest:Vehicle):Observable<Vehicle[]>
  {
    return this.http.put<Vehicle[]>(this.baseUrl+'/api/Vehicle/'+id,editvehicleRequest);
  }

  deleteVehicle(id:string):Observable<Vehicle[]>
  {
    return this.http.delete<Vehicle[]>(this.baseUrl+'/api/Vehicle/'+id);
  }


}
