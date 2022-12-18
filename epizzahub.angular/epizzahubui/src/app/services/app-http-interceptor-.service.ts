import { Injectable } from '@angular/core';
import {
   HttpClient, HttpClientModule, HTTP_INTERCEPTORS,
   HttpInterceptor, HttpRequest, HttpResponse, HttpHandler,
   HttpEvent, HttpErrorResponse
} from '@angular/common/http';
import { Observable, throwError, map, retry, catchError, tap, finalize } from 'rxjs';
import { GbobalEventService } from './gbobal-event.service';
import { ToastrInfo } from '../models/toastrInfo';

@Injectable({
   providedIn: 'root'
})
export class AppHttpInterceptorService implements HttpInterceptor {

   constructor(private globalEvent$: GbobalEventService) {

   }


   intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
      this.globalEvent$.spinner.next("show");


      return next.handle(req)
         .pipe(
            retry(0),
            catchError(this.handleError),
            finalize(() => {  //setTimeout( () => {
               //  this.globalEvent$.spinner.next("hide") 
               // }, 200000 );
               this.globalEvent$.spinner.next("hide");
            }

            )
         )

   }

   handleError(error: HttpErrorResponse) {
      let errorMessage = '';
      if (error instanceof HttpErrorResponse) {
         if (error.error instanceof ErrorEvent) {
            errorMessage = `Error: ${error.error.message}`;
            return throwError(() => new Error(errorMessage));
         }

         else {
            switch (error.status) {
               case 400:
                  {
                     errorMessage = 'Authentication failed';
                     this.globalEvent$.notification.next(
                        new ToastrInfo('error', errorMessage));
                     return throwError(() => new Error(errorMessage));
                  }
               case 401:
               case 403:
               case 404:
                  {
                     errorMessage = `Error: ${error.error}`;
                     this.globalEvent$.notification.next(
                        new ToastrInfo('error', errorMessage));
                     return throwError(() => new Error(errorMessage));
                  }

               case 500:
                  {
                     errorMessage = `Error: ${error.error}`;
                     return throwError(() => new Error(errorMessage));
                  }

               default:
                  {
                     errorMessage = `Error: ${error.error}`;
                     return throwError(() => new Error(errorMessage));
                  }

            }
         }
      }
      else {
         errorMessage = "some unknown error has occured";
         return throwError(() => new Error(errorMessage));
      }

   }

}
