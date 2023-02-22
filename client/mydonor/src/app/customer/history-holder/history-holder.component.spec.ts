import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HistoryHolderComponent } from './history-holder.component';

describe('HistoryHolderComponent', () => {
  let component: HistoryHolderComponent;
  let fixture: ComponentFixture<HistoryHolderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [HistoryHolderComponent]
    })
      .compileComponents();

    fixture = TestBed.createComponent(HistoryHolderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
