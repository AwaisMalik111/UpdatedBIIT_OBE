import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TsidebarComponent } from './tsidebar.component';

describe('TsidebarComponent', () => {
  let component: TsidebarComponent;
  let fixture: ComponentFixture<TsidebarComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TsidebarComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TsidebarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
