import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NotificationsService } from '../notifications/notifications.service';
import { CoberturaService } from '../_services/cobertura.service';
import { Router } from '@angular/router';
import { GetCoberturas } from '../_models/GetCoberturas';

@Component({
   selector: 'app-cobertura',
   templateUrl: './cobertura.component.html',
   styleUrls: ['./cobertura.component.css'],
})
export class CoberturaComponent implements OnInit {
   coberturaForm: FormGroup = new FormGroup({});
   coberturas: GetCoberturas[] = [];

   constructor(
      private coberturasService: CoberturaService,
      private router: Router,
      private fb: FormBuilder,
      private notification: NotificationsService
   ) {}

   ngOnInit(): void {
      this.initializeForm();
      this.getCobs();
   }

   getCobs() {
      this.coberturasService.getCoberturas().subscribe({
         next: (res) => {
            this.coberturas = res;

            console.log(this.coberturas, 'cooooobs');
         },
      });
   }

   initializeForm() {
      this.coberturaForm = this.fb.group({
         descripcion: ['', [Validators.required, Validators.maxLength(22)]],
         monto: [1, Validators.required],
      });
   }

   agregar() {
      console.log(this.coberturaForm.value);

      this.coberturasService.postCobertura(this.coberturaForm.value).subscribe({
         next: () => {
            // this.router.navigateByUrl('/cotizar');

            this.notification.addNoti({
               severity: 'success',
               summary: 'Excelente.',
               detail: 'Cobertura agregada con éxito.',
            });

            this.getCobs();
         },
      });
   }
}
