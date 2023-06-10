import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { GetCoberturas } from 'src/app/_models/GetCoberturas';
import { CoberturaService } from 'src/app/_services/cobertura.service';
import { NotificationsService } from 'src/app/notifications/notifications.service';

@Component({
   selector: 'app-edit-cobs',
   templateUrl: './edit-cobs.component.html',
   styleUrls: ['./edit-cobs.component.css'],
})
export class EditCobsComponent implements OnInit {
   coberturaForm: FormGroup = new FormGroup({});
   cob: GetCoberturas;

   constructor(
      private router: Router,
      private fb: FormBuilder,
      private cobsService: CoberturaService,
      private notification: NotificationsService
   ) {
      const navigation = this.router.getCurrentNavigation();

      if (!navigation?.extras?.state?.['Cob'])
         router.navigateByUrl('/cobertura');

      this.cob = navigation?.extras?.state?.['Cob'];
   }

   ngOnInit(): void {
      this.initializeForm();
   }

   initializeForm() {
      this.coberturaForm = this.fb.group({
         descripcion: [
            this.cob.descripcion,
            [Validators.required, Validators.maxLength(22)],
         ],
         monto: [this.cob.monto, Validators.required],
         coberturaId: [this.cob.coberturaId, Validators.required],
      });
   }

   editar() {
      this.cobsService.editCob(this.coberturaForm.value).subscribe({
         next: () => {
            this.router.navigateByUrl('/cobertura');

            this.notification.addNoti({
               severity: 'success',
               summary: 'Listo.',
               detail: 'Cobertura editada con éxito.',
            });
         },
      });
   }
}
