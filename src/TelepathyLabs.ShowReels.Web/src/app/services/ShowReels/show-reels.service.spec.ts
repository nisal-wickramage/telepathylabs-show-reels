import { TestBed } from '@angular/core/testing';

import { ShowReelsService } from './show-reels.service';

describe('ShowReelsService', () => {
  let service: ShowReelsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ShowReelsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
