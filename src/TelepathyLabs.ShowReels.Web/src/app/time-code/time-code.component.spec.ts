import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TimeCodeComponent } from './time-code.component';

describe('TimeCodeComponent', () => {
  let component: TimeCodeComponent;
  let fixture: ComponentFixture<TimeCodeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TimeCodeComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TimeCodeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
