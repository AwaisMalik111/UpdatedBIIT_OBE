import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TeacherNotifyComponent } from './teacher-notify.component';

describe('TeacherNotifyComponent', () => {
  let component: TeacherNotifyComponent;
  let fixture: ComponentFixture<TeacherNotifyComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TeacherNotifyComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TeacherNotifyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
