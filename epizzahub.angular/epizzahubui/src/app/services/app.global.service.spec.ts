/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { GlobalVars } from './app.global.service';

describe('Service: GlobalVars', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [GlobalVars]
    });
  });

  it('should be created', inject([GlobalVars], (service: GlobalVars) => {
    expect(service).toBeTruthy();
  }));
});
