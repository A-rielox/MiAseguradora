import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginModel } from 'src/app/_models/LoginModel';
import { AccountService } from 'src/app/_services/account.service';
import { NotificationsService } from 'src/app/notifications/notifications.service';

@Component({
   selector: 'app-login-modal',
   templateUrl: './login-modal.component.html',
   styleUrls: ['./login-modal.component.css'],
})
export class LoginModalComponent implements OnInit {
   loginForm: LoginModel = {} as LoginModel;
   visibleLogin = false;

   constructor(
      private accountService: AccountService,
      private router: Router,
      private notification: NotificationsService
   ) {}

   ngOnInit(): void {
      this.loginForm.username = 'earnestine';
      this.loginForm.password = 'P@ssword1';
   }

   openLogin() {
      this.visibleLogin = !this.visibleLogin;
   }

   login() {
      this.accountService.login(this.loginForm).subscribe({
         next: () => {
            this.router.navigateByUrl('/polizas');

            this.notification.addNoti({
               severity: 'success',
               summary: 'Hola.',
               detail: 'Que bueno tenerte de vuelta.',
            });
         },
         error: (err) => {},
      });

      this.visibleLogin = false;
   }
}
