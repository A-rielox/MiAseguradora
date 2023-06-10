import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { AddPoliza } from 'src/app/_models/AddPoliza';
import { Cobertura } from 'src/app/_models/Cobertura';
import { EditPoliza } from 'src/app/_models/EditPoliza';
import { EditPolizaSend } from 'src/app/_models/EditPolizaSend';
import { PolizasService } from 'src/app/_services/polizas.service';
import { NotificationsService } from 'src/app/notifications/notifications.service';

@Component({
   selector: 'app-coberturas',
   templateUrl: './coberturas.component.html',
   styleUrls: ['./coberturas.component.css'],
})
export class CoberturasComponent implements OnInit {
   @Input() catalogos: Cobertura[] = [];
   @Input() polizaSelected?: boolean; // cambia pantalla
   @Output() rejectPoliza = new EventEmitter<boolean>(); // cambia pantalla
   @Input() vehiculo: number = 1;
   @Input() poliza: EditPoliza = {} as EditPoliza;

   selectedProducts: number[] = [];
   catalogoAjustado: Cobertura[] = [];

   constructor(
      private polizasService: PolizasService,
      private router: Router,
      private notification: NotificationsService
   ) {}

   ngOnChanges(): void {
      this.catalogoAjustado = this.setCoberturas();

      // console.log(this.poliza, 'poliza edit');

      // p' preseleccionar los checkboxes
      this.selectedProducts = this.poliza.coberturasIdsList.map((c) => {
         return c.coberturaId;
      });
   }

   ngOnInit(): void {}

   addPoCo() {
      let poco: EditPolizaSend = {
         ...this.poliza,
         polizaId: this.poliza.polizaId,
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

      console.log(poco, 'poco edit');
      // {Marca: 'marca', Vehiculo: 2000, Modelo: 'modelo', coberturasIdsList:  [4, 1]}

      this.polizasService.editPoCo(poco).subscribe({
         next: () => {
            this.router.navigateByUrl('/polizas');

            this.notification.addNoti({
               severity: 'success',
               summary: 'Excelente.',
               detail: 'Póliza editada con éxito.',
            });
         },
      });

      /*        lo q sale pal edit
      {
         "polizaId": 37,
         "marca": "marca",
         "vehiculo": "2020",
         "modelo": "modelo",
         "coberturasIdsList": [ 1, 3 ]
      }
      */
   }

   // print() {
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
