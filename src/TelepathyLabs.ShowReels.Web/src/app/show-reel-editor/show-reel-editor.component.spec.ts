import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowReelEditorComponent } from './show-reel-editor.component';

describe('ShowReelEditorComponent', () => {
  let component: ShowReelEditorComponent;
  let fixture: ComponentFixture<ShowReelEditorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowReelEditorComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShowReelEditorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
