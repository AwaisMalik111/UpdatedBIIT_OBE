import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HclosComponent } from './hclos.component';

describe('HclosComponent', () => {
  let component: HclosComponent;
  let fixture: ComponentFixture<HclosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HclosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HclosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
