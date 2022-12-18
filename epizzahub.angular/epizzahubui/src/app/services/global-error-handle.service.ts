import { HttpErrorResponse } from '@angular/common/http';
import { ErrorHandler, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class GlobalErrorHandleService implements ErrorHandler {

  constructor() { }

  handleError(error: Error | HttpErrorResponse) {
    console.error('An error occurred:', error.message);
    console.error(error);
    alert(error);
  }

}
