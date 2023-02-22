import { ComponentFixture, TestBed } from '@angular/core/testing';
import { StockviewComponent } from './stockview.component';

describe('StockviewComponent', () => {
  let component: StockviewComponent;
  let fixture: ComponentFixture<StockviewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [StockviewComponent]
    })
      .compileComponents();

    fixture = TestBed.createComponent(StockviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
