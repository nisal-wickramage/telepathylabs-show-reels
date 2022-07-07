import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowReelInformationComponent } from './show-reel-information.component';

describe('ShowReelInformationComponent', () => {
  let component: ShowReelInformationComponent;
  let fixture: ComponentFixture<ShowReelInformationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowReelInformationComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShowReelInformationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
