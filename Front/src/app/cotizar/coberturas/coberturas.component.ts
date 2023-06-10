import {
   Component,
   EventEmitter,
   Input,
   OnChanges,
   OnInit,
   Output,
   SimpleChanges,
} from '@angular/core';
import { Router } from '@angular/router';
import { AddPoliza } from 'src/app/_models/AddPoliza';
import { Cobertura } from 'src/app/_models/Cobertura';
import { PolizaRegistro } from 'src/app/_models/PolizaRegistro';
import { PolizasService } from 'src/app/_services/polizas.service';
import { NotificationsService } from 'src/app/notifications/notifications.service';

@Component({
   selector: 'app-coberturas',
   templateUrl: './coberturas.component.html',
   styleUrls: ['./coberturas.component.css'],
})
export class CoberturasComponent implements OnInit, OnChanges {
   @Input() catalogos: Cobertura[] = [];
   @Input() polizaSelected?: boolean; // cambia pantalla
   @Output() rejectPoliza = new EventEmitter<boolean>(); // cambia pantalla
   @Input() vehiculo: number = 1;
   @Input() poliza: PolizaRegistro = {} as PolizaRegistro;

   selectedProducts: number[] = [];
   catalogoAjustado: Cobertura[] = [];

   constructor(
      private polizasService: PolizasService,
      private router: Router,
      private notification: NotificationsService
   ) {}

   ngOnChanges(): void {
      this.catalogoAjustado = this.setCoberturas();
   }

   ngOnInit(): void {}

   addPoCo() {
      let poco: AddPoliza = {
         ...this.poliza,
         vehiculo: this.vehiculo.toString(),
         coberturasIdsList: this.selectedProducts,
      };

      if (poco.coberturasIdsList.length < 1) {
         this.notification.addNoti({
            severity: 'error',
            summary: 'Lo siento.',
            detail: 'Debes incluir coberturas.',
         });

         return;
      }

      // console.log(poco, 'poco');
      // {Marca: 'marca', Vehiculo: 2000, Modelo: 'modelo', coberturasIdsList:  [4, 1]}

      this.polizasService.postPoCo(poco).subscribe({
         next: () => {
            this.router.navigateByUrl('/polizas');

            this.notification.addNoti({
               severity: 'success',
               summary: 'Excelente.',
               detail: 'Póliza agregada con éxito.',
            });
         },
      });
   }

   // print() {
   //    console.log(this.catalogos, 'this.catalogo');
   //    console.log(this.selectedProducts, 'this.selectedProducts'); // [4, 1]
   // }

   setCoberturas() {
      let catalogoAjustado = this.catalogos.map((cob) => {
         let newMonto = cob.monto + cob.monto * this.vehiculo * 0.001;

         let newCob = {
            coberturaId: cob.coberturaId,
            descripcion: cob.descripcion,
            monto: newMonto,
         };

         return newCob;
      });

      return catalogoAjustado;
   }

   reject() {
      this.rejectPoliza.emit(true);
   }
}
