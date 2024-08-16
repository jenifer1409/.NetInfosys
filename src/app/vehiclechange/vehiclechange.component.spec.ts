import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VehiclechangeComponent } from './vehiclechange.component';

describe('VehiclechangeComponent', () => {
  let component: VehiclechangeComponent;
  let fixture: ComponentFixture<VehiclechangeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [VehiclechangeComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(VehiclechangeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
