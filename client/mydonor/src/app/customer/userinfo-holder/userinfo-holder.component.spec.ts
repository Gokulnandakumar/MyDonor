import { ComponentFixture, TestBed } from '@angular/core/testing';
import { UserinfoHolderComponent } from './userinfo-holder.component';

describe('UserinfoHolderComponent', () => {
  let component: UserinfoHolderComponent;
  let fixture: ComponentFixture<UserinfoHolderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [UserinfoHolderComponent]
    })
      .compileComponents();

    fixture = TestBed.createComponent(UserinfoHolderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
