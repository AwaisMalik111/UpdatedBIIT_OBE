import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PloMappingComponent } from './plo-mapping.component';

describe('PloMappingComponent', () => {
  let component: PloMappingComponent;
  let fixture: ComponentFixture<PloMappingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PloMappingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PloMappingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
