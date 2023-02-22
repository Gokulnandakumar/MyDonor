import { ComponentFixture, TestBed } from '@angular/core/testing';
import { AppoinmentHolderComponent } from './appoinment-holder.component';

describe('AppoinmentHolderComponent', () => {
  let component: AppoinmentHolderComponent;
  let fixture: ComponentFixture<AppoinmentHolderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AppoinmentHolderComponent]
    })
      .compileComponents();

    fixture = TestBed.createComponent(AppoinmentHolderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
