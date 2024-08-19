import { TestBed } from '@angular/core/testing';
import { VehicleService } from './vehicle.service';
import { Vehicle } from './vehicle';
import { HttpTestingController, provideHttpClientTesting} from '@angular/common/http/testing';
import { provideHttpClient } from '@angular/common/http';



describe('VehicleService', () => {
  let service: VehicleService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        VehicleService, 
        provideHttpClient(),
        provideHttpClientTesting() 
    });

    service = TestBed.inject(VehicleService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should retrieve all the vehicles', () => {
    const sampleVehicles: Vehicle[] = [
      { regId: '35db87b6-c6aa-4526-9a6a-c68d80ed1628', vehicleId: 'mx123', model: 'ford', lastServiceDate: new Date() },
      { regId: '8890a3a0-5cd0-45a7-b293-06b6e5736114', vehicleId: 'ad123', model: 'kia', lastServiceDate: new Date() }
    ];

    service.getAllVehicles().subscribe((vehicles: Vehicle[]) => {  // Specify the type here
      expect(vehicles.length).toBe(2);
      expect(vehicles).toEqual(sampleVehicles);
    });

    const req = httpMock.expectOne(`${service.baseUrl}/api/Vehicle/GetAll`);
    expect(req.request.method).toBe('GET');
    req.flush(sampleVehicles);
  });


  it('should retrive a vehicle by Id',()=>
  {
    const sampleVehicle: Vehicle = 
      { regId: '35db87b6-c6aa-4526-9a6a-c68d80ed1628', vehicleId: 'mx123', model: 'ford', lastServiceDate: new Date() };
    service.getByIdVehicle('35db87b6-c6aa-4526-9a6a-c68d80ed1628').subscribe((vehicle)=>
    {
      expect(vehicle).toEqual(sampleVehicle);
    });

    const req = httpMock.expectOne(`${service.baseUrl}/api/Vehicle/GetById?id=35db87b6-c6aa-4526-9a6a-c68d80ed1628`);
    expect(req.request.method).toBe('GET');
    req.flush(sampleVehicle);

  })

  it('should add a new vehicle',()=>
  {
    const newVehicle:Vehicle={ regId: '35db87b6-c6aa-4526-9a6a-c68d80ed1628', vehicleId: 'mx123', model: 'ford', lastServiceDate: new Date()};
    service.addVehicle(newVehicle).subscribe((vehicles)=>
    {
      expect(vehicles).toContain(newVehicle);
    });
    const req = httpMock.expectOne(`${service.baseUrl}/api/Vehicle/addVehicle`);
    expect(req.request.method).toBe('POST');
    req.flush([newVehicle]);

  })

  it('should edit a new vehicle',()=>
    {
      const editVehicle:Vehicle={ regId: '35db87b6-c6aa-4526-9a6a-c68d80ed1628', vehicleId: 'mx123', model: 'ford', lastServiceDate: new Date()};
      service.editVehicle('35db87b6-c6aa-4526-9a6a-c68d80ed1628',editVehicle).subscribe((vehicles)=>
      {
        expect(vehicles).toContain(editVehicle);
      });
      const req = httpMock.expectOne(`${service.baseUrl}/api/Vehicle/35db87b6-c6aa-4526-9a6a-c68d80ed1628`);
      expect(req.request.method).toBe('PUT');
      req.flush([editVehicle]);
  
    })

    it('should delete a new vehicle',()=>
      {
        const deleteVehicle:Vehicle={ regId: '35db87b6-c6aa-4526-9a6a-c68d80ed1628', vehicleId: 'mx123', model: 'ford', lastServiceDate: new Date()};
        service.deleteVehicle('35db87b6-c6aa-4526-9a6a-c68d80ed1628').subscribe((vehicles)=>
        {
          expect(vehicles).toContain(deleteVehicle);
        });
        const req = httpMock.expectOne(`${service.baseUrl}/api/Vehicle/35db87b6-c6aa-4526-9a6a-c68d80ed1628`);
        expect(req.request.method).toBe('DELETE');
        req.flush([deleteVehicle]);
    
      })
});


