import { TestBed } from '@angular/core/testing';

import { VideoStandardService } from './video-standard.service';

describe('VideoStandardService', () => {
  let service: VideoStandardService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(VideoStandardService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
