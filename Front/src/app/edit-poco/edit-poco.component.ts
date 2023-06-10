import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Poliza } from '../_models/Poliza';
import { Cobertura } from '../_models/Cobertura';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PolizasService } from '../_services/polizas.service';

@Component({
   selector: 'app-edit-poco',
   templateUrl: './edit-poco.component.html',
   styleUrls: ['./edit-poco.component.css'],
})
export class EditPocoComponent implements OnInit {
   coberturasCatalogoList: Cobertura[] = [];
   polizaForm: FormGroup = new FormGroup({});

   polizaSelected: boolean = false; // p' cambiar de pantalla
   ///////////
   poco: Poliza;

   constructor(
      private polizasService: PolizasService,
      private fb: FormBuilder,
      private router: Router
   ) {
      const navigation = this.router.getCurrentNavigation();

      if (!navigation?.extras?.state?.['Poco'])
         router.navigateByUrl('/polizas');

      this.poco = navigation?.extras?.state?.['Poco'];
   }

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
         polizaId: [this.poco.polizaId, Validators.required],
         marca: [this.poco.marca, Validators.required],
         vehiculo: [this.poco.vehiculo, Validators.required],
         modelo: [this.poco.modelo, Validators.required],
         coberturasIdsList: [this.poco.coberturasIdList, Validators.required],
      });
   }

   cotizarPoliza() {
      // console.log(this.polizaForm.value, 'xs');
      this.polizaSelected = true;
   }

   rejectPoliza() {
      this.polizaSelected = false;
      // cancelar devolver a /polizas
   }
}

/*        lo q sale pal edit

{
   "polizaId": 37,
   "marca": "marca",
   "vehiculo": "2020",
   "modelo": "modelo",
   "coberturasIdsList": [ 1, 3 ]
}
*/
