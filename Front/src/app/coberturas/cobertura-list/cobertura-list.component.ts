import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NavigationExtras, Router } from '@angular/router';
import { ConfirmationService } from 'primeng/api';
import { GetCoberturas } from 'src/app/_models/GetCoberturas';
import { CoberturaService } from 'src/app/_services/cobertura.service';
import { NotificationsService } from 'src/app/notifications/notifications.service';

@Component({
   selector: 'app-cobertura-list',
   templateUrl: './cobertura-list.component.html',
   styleUrls: ['./cobertura-list.component.css'],
   providers: [ConfirmationService],
})
export class CoberturaListComponent implements OnInit {
   @Input() coberturas: GetCoberturas[] = [];
   @Output() getCobs = new EventEmitter<boolean>();

   constructor(
      private confirmationService: ConfirmationService,
      private router: Router,
      private notification: NotificationsService,
      private cobsService: CoberturaService
   ) {}

   ngOnInit(): void {}

   // pop-up de confirmar borrado
   confirm(event: Event, cob: GetCoberturas) {
      if (!event.target) return;

      this.confirmationService.confirm({
         target: event.target as EventTarget,
         message: 'Confirmas que quieres borrar la cobertura?',
         acceptLabel: 'Si',
         rejectLabel: 'No',
         icon: 'pi pi-exclamation-triangle',
         accept: () => {
            if (!this.coberturas) return;

            this.cobsService.deleteCob(cob.coberturaId).subscribe({
               next: (_) => {
                  this.notification.addNoti({
                     severity: 'success',
                     summary: 'Listo',
                     detail: 'Poliza borrada',
                  });

                  this.getCobs.emit(true);
               },
            });
         },
         reject: () => {},
      });
   }

   goToEdit(cobertura: GetCoberturas) {
      const navigationExtras: NavigationExtras = {
         state: { Cob: cobertura },
      };

      console.log(cobertura);

      this.router.navigateByUrl('/edit-cob', navigationExtras);
   }
}
