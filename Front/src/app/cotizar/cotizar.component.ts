import { Component, OnInit } from '@angular/core';
import { PolizasService } from '../_services/polizas.service';
import { Cobertura } from '../_models/Cobertura';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
   selector: 'app-cotizar',
   templateUrl: './cotizar.component.html',
   styleUrls: ['./cotizar.component.css'],
})
export class CotizarComponent implements OnInit {
   coberturasCatalogoList: Cobertura[] = [];
   polizaForm: FormGroup = new FormGroup({});

   polizaSelected: boolean = false;

   constructor(
      private polizasService: PolizasService,
      private fb: FormBuilder
   ) {}

   ngOnInit(): void {
      this.getCoberturasCatalogo();
      this.initializeForm();
   }

   getCoberturasCatalogo() {
      this.polizasService.getCoberturas().subscribe({
         next: (res) => {
            this.coberturasCatalogoList = res;
         },
      });
   }

   initializeForm() {
      this.polizaForm = this.fb.group({
         marca: ['', Validators.required],
         vehiculo: [1980, Validators.required],
         modelo: ['', Validators.required],
      });
   }

   cotizarPoliza() {
      // console.log(this.polizaForm.value, 'xs');
      this.polizaSelected = true;
   }

   rejectPoliza() {
      this.polizaSelected = false;
   }
}
