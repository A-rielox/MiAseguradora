import { Component, OnInit } from '@angular/core';
import { LoggedUsuario } from './_models/LoggedUsuario';
import { AccountService } from './_services/account.service';

@Component({
   selector: 'app-root',
   templateUrl: './app.component.html',
   styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
   usuarios: LoggedUsuario[] = [];

   constructor(private accountService: AccountService) {}

   ngOnInit(): void {
      this.setCurrentUser();
   }

   setCurrentUser() {
      const localUser = localStorage.getItem('user');

      if (!localUser) return;

      const user: LoggedUsuario = JSON.parse(localUser);

      this.accountService.setCurrentUser(user);
   }
}
