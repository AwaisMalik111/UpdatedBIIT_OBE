import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CLOManagementComponent } from './clo-management.component';

describe('CLOManagementComponent', () => {
  let component: CLOManagementComponent;
  let fixture: ComponentFixture<CLOManagementComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CLOManagementComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CLOManagementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
