import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FCARComponent } from './fcar.component';

describe('FCARComponent', () => {
  let component: FCARComponent;
  let fixture: ComponentFixture<FCARComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FCARComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FCARComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
