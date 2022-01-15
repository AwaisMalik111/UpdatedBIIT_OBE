import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HODSidebarComponent } from './hod-sidebar.component';

describe('HODSidebarComponent', () => {
  let component: HODSidebarComponent;
  let fixture: ComponentFixture<HODSidebarComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HODSidebarComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HODSidebarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
