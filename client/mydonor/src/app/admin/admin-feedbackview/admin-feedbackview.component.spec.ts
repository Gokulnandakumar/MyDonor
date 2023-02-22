import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminFeedbackviewComponent } from './admin-feedbackview.component';

describe('AdminFeedbackviewComponent', () => {
  let component: AdminFeedbackviewComponent;
  let fixture: ComponentFixture<AdminFeedbackviewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminFeedbackviewComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AdminFeedbackviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
