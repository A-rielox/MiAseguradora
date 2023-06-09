import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { Observable, map } from 'rxjs';
import { AccountService } from '../_services/account.service';
import { NotificationsService } from '../notifications/notifications.service';

@Injectable({
   providedIn: 'root',
})
export class AuthGuard implements CanActivate {
   constructor(
      private accountService: AccountService,
      private notification: NotificationsService,
      private router: Router
   ) {}

   canActivate(): Observable<boolean> {
      return this.accountService.currentUser$.pipe(
         map((user) => {
            if (user) return true;
            else {
               this.notification.addNoti({
                  severity: 'warn',
                  summary: 'Lo sentimos.',
                  detail: 'Solo usuarios registrados.',
               });

               this.router.navigateByUrl('/');

               return false;
            }
         })
      );
   }
}
