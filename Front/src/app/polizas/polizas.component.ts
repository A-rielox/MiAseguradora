import { Component, OnInit } from '@angular/core';
import { PolizasService } from '../_services/polizas.service';
import { Poliza } from '../_models/Poliza';
import { Cobertura } from '../_models/Cobertura';
import { PolizaPlus } from '../_models/PolizaPlus';

@Component({
   selector: 'app-polizas',
   templateUrl: './polizas.component.html',
   styleUrls: ['./polizas.component.css'],
})
export class PolizasComponent implements OnInit {
   polizas: Poliza[] = [];
   coberturasCatalogoList: Cobertura[] = [];
   myPolizas: PolizaPlus[] = [];

   constructor(private polizasService: PolizasService) {}

   ngOnInit(): void {
      this.getCoberturasCatalogo();
   }

   getUserPolizas() {
      this.polizasService.getPolizasForUser().subscribe({
         next: (res) => {
            this.polizas = res;
            console.log(this.polizas, 'polizas');
            // console.log(this.setCoberturas(), 'polizas ++++');

            this.myPolizas = this.setCoberturas();
            console.log(this.myPolizas, 'xxxxxxxx');
         },
      });
   }

   getCoberturasCatalogo() {
      this.polizasService.getCoberturas().subscribe({
         next: (res) => {
            this.coberturasCatalogoList = res;
            this.getUserPolizas();
         },
      });
   }

   setCoberturas() {
      let polizas: PolizaPlus[] = [];

      this.polizas.forEach((p) => {
         let coberturas = [];

         for (const cobId of p.coberturasIdList) {
            let cobertura = this.coberturasCatalogoList.find(
               (c) => c.coberturaId === cobId
            );

            // console.log(cobertura, 'cobertura');
            if (cobertura) {
               let monto =
                  cobertura.monto + cobertura.monto * +p.vehiculo * 0.001;

               coberturas.push({ ...cobertura, monto: monto });
            }
         }

         let poliza = { ...p, coberturasIdList: coberturas };
         // console.log(poliza, 'poliza++++');

         polizas.push(poliza);
      });

      // // ( cob.Monto + (cob.Monto * int.Parse( poCoCreateDto.Vehiculo ) * 0.001) )

      return polizas;
   }

   getMonto(monto: number) {
      return monto * 2;
   }

   border2Color(vehiculo: string) {
      let lastDigit = vehiculo.slice(-1);

      switch (lastDigit) {
         case '0':
         case '1':
            return 'border-color: #06d465';

         case '2':
         case '3':
            return 'border-color: #eae91c';

         case '4':
         case '5':
            return 'border-color: #f91616';

         case '6':
         case '7':
            return 'border-color: #cc63f1';

         default:
            return 'border-color: #06b6d4';

         //  #eae91c   #6d1e70   #cc63f1   #6366f1   #f97316'
      }
   }
}
