import { TestBed } from '@angular/core/testing';

import { VideoDefinitionService } from './video-definition.service';

describe('VideoDefinitionServiceService', () => {
  let service: VideoDefinitionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(VideoDefinitionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
