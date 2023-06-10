import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Poliza } from '../_models/Poliza';
import { Cobertura } from '../_models/Cobertura';
import { AddPoliza } from '../_models/AddPoliza';
import { EditPolizaSend } from '../_models/EditPolizaSend';

@Injectable({
   providedIn: 'root',
})
export class PolizasService {
   baseUrl = environment.apiUrl;

   constructor(private http: HttpClient) {}

   getCoberturas() {
      return this.http.get<Cobertura[]>(this.baseUrl + 'Coberturas');
   }

   getPolizasForUser() {
      return this.http.get<Poliza[]>(this.baseUrl + 'Polizas');
   }

   postPoCo(polizaForm: AddPoliza) {
      return this.http.post(this.baseUrl + 'Polizas', polizaForm);
   }

   editPoCo(editPolizaForm: EditPolizaSend) {
      return this.http.put(this.baseUrl + 'Polizas', editPolizaForm);
   }

   deletePoCo(pocoId: number) {
      return this.http.delete(this.baseUrl + 'Polizas/' + pocoId);
   }
}
