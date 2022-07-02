import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowReelListComponent } from './show-reel-list.component';

describe('ShowReelListComponent', () => {
  let component: ShowReelListComponent;
  let fixture: ComponentFixture<ShowReelListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowReelListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShowReelListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
