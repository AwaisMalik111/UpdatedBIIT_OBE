import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TeacherClosComponent } from './teacher-clos.component';

describe('TeacherClosComponent', () => {
  let component: TeacherClosComponent;
  let fixture: ComponentFixture<TeacherClosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TeacherClosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TeacherClosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
