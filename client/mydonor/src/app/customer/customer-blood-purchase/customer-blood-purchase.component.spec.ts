import { ComponentFixture, TestBed } from '@angular/core/testing';
import { CustomerBloodPurchaseComponent } from './customer-blood-purchase.component';

describe('CustomerBloodPurchaseComponent', () => {
  let component: CustomerBloodPurchaseComponent;
  let fixture: ComponentFixture<CustomerBloodPurchaseComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CustomerBloodPurchaseComponent]
    })
      .compileComponents();

    fixture = TestBed.createComponent(CustomerBloodPurchaseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
