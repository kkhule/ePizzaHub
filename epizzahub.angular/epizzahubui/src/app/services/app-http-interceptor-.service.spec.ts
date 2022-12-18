/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { AppHttpInterceptorService } from './app-http-interceptor-.service';

describe('Service: AppHttpInterceptor-', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AppHttpInterceptorService]
    });
  });

  it('should be created', inject([AppHttpInterceptorService], (service: AppHttpInterceptorService) => {
    expect(service).toBeTruthy();
  }));
});
