import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HodNotifyComponent } from './hod-notify.component';

describe('HodNotifyComponent', () => {
  let component: HodNotifyComponent;
  let fixture: ComponentFixture<HodNotifyComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HodNotifyComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HodNotifyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
