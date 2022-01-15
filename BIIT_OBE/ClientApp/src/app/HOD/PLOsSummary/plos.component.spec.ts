import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PlosComponent } from './plos.component';

describe('PlosComponent', () => {
  let component: PlosComponent;
  let fixture: ComponentFixture<PlosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PlosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PlosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
