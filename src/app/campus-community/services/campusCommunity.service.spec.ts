import {TestBed} from '@angular/core/testing';

import {CampusCommunityService} from './campusCommunity.service';

describe('CampusCommunityService', () => {
  let service: CampusCommunityService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CampusCommunityService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
