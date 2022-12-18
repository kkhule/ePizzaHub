/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { GbobalEventService } from './gbobal-event.service';

describe('Service: GbobalEvent.service', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [GbobalEventService]
    });
  });

  it('should be created', inject([GbobalEventService], (service: GbobalEventService) => {
    expect(service).toBeTruthy();
  }));
});
