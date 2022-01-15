import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ClosComponent } from './clos.component';

describe('ClosComponent', () => {
  let component: ClosComponent;
  let fixture: ComponentFixture<ClosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ClosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ClosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
