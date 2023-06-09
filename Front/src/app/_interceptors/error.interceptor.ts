import { Injectable } from '@angular/core';
import {
   HttpRequest,
   HttpHandler,
   HttpEvent,
   HttpInterceptor,
   HttpErrorResponse,
} from '@angular/common/http';
import { Observable, catchError } from 'rxjs';
import { Router } from '@angular/router';
import { NotificationsService } from '../notifications/notifications.service';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
   constructor(
      private router: Router,
      private notification: NotificationsService
   ) {}

   intercept(
      request: HttpRequest<unknown>,
      next: HttpHandler
   ): Observable<HttpEvent<unknown>> {
      return next.handle(request).pipe(
         catchError((error: HttpErrorResponse) => {
            if (error) {
               switch (error.status) {
                  case 400:
                     if (error.error.errors) {
                        // este es el de validacion de las formas error de validacion
                        const modalStateErrors = [];

                        for (const key in error.error.errors) {
                           if (error.error.errors[key]) {
                              modalStateErrors.push(error.error.errors[key]);
                           }
                        }

                        // el error q tiro aca se agarra en el ".subscribe({ error: ... })" ( en el error del subscribe del request
                        throw modalStateErrors.flat();
                     } else if (typeof error.error === 'object') {
                        // this.toastr.error(
                        //    error.statusText,
                        //    error.status.toString()
                        // );

                        this.notification.addNoti({
                           severity: 'error',
                           summary: 'Error ' + error.status.toString(),
                           detail: error.statusText,
                        });
                     } else {
                        this.notification.addNoti({
                           severity: 'error',
                           summary: 'Error ' + error.status.toString(),
                           detail: error.error,
                        });
                     }
                     break;

                  case 401:
                     this.notification.addNoti({
                        severity: 'error',
                        summary: 'Error ' + error.status.toString(),
                        detail: 'Sin Autorización.',
                     });

                     break;

                  case 404:
                     // this.router.navigateByUrl('/not-found');
                     this.router.navigateByUrl('/');
                     break;

                  case 500:
                     this.router.navigateByUrl('/');
                     break;

                  default:
                     this.notification.addNoti({
                        severity: 'error',
                        summary: 'Error ' + error.status.toString(),
                        detail: 'Algo inesperado salió mal.',
                     });

                     console.log(error);
                     break;
               }
            }

            // return throwError(error);
            throw error;
         })
      );
   }
}
