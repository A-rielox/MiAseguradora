import { Component, OnInit } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { AccountService } from '../_services/account.service';
import { Router } from '@angular/router';
import { NotificationsService } from '../notifications/notifications.service';

@Component({
   selector: 'app-nav',
   templateUrl: './nav.component.html',
   styleUrls: ['./nav.component.css'],
})
export class NavComponent implements OnInit {
   items: MenuItem[] = [];
   navItems: MenuItem[] = [];

   constructor(
      public accountService: AccountService,
      private router: Router,
      private notification: NotificationsService
   ) {}

   ngOnInit(): void {
      this.setItems();
   }

   logout() {
      this.accountService.logout();

      this.router.navigateByUrl('/');

      this.notification.addNoti({
         severity: 'success',
         summary: 'Adios.',
         detail: 'Nos vemos pronto.',
      });
   }

   setItems() {
      this.items = [
         {
            label: 'Editar Perfil',
            icon: 'pi pi-cog',
            routerLink: ['/'],
         },
         {
            label: 'Salir',
            icon: 'pi pi-sign-out',
            command: () => {
               this.logout();
            },
         },
      ];

      this.navItems = [
         {
            label: 'Home',
            icon: 'pi pi-home',
            routerLink: ['/'],
         },
         {
            label: 'Salir',
            icon: 'pi pi-sign-out',
         },
      ];
   }

   aClass() {
      return 'flex h-full px-6 p-3 lg:px-3 lg:py-2 align-items-center text-600 hover:text-900 border-left-2 lg:border-bottom-2 lg:border-left-none border-transparent hover:border-primary font-medium cursor-pointer transition-colors transition-duration-150';
   }
}
