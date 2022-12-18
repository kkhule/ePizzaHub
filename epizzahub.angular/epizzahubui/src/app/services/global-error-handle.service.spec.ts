/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { GlobalErrorHandleService } from './global-error-handle.service';

describe('Service: GlobalErrorHandle', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [GlobalErrorHandleService]
    });
  });

  it('should be created', inject([GlobalErrorHandleService], (service: GlobalErrorHandleService) => {
    expect(service).toBeTruthy();
  }));
});
