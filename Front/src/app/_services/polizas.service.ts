import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Poliza } from '../_models/Poliza';
import { Cobertura } from '../_models/Cobertura';
import { AddPoliza } from '../_models/AddPoliza';

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
}
