import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RequestClickedComponent } from './request-clicked.component';

describe('RequestClickedComponent', () => {
  let component: RequestClickedComponent;
  let fixture: ComponentFixture<RequestClickedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RequestClickedComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RequestClickedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
