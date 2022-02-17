import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BriefTranscriptComponent } from './brief-transcript.component';

describe('BriefTranscriptComponent', () => {
  let component: BriefTranscriptComponent;
  let fixture: ComponentFixture<BriefTranscriptComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BriefTranscriptComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BriefTranscriptComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
