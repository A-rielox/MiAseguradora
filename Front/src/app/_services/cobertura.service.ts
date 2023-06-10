import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { AddCobertura } from '../_models/AddCobertura';
import { GetCoberturas } from '../_models/GetCoberturas';

@Injectable({
   providedIn: 'root',
})
export class CoberturaService {
   baseUrl = environment.apiUrl;

   constructor(private http: HttpClient) {}

   getCoberturas() {
      return this.http.get<GetCoberturas[]>(this.baseUrl + 'Coberturas');
   }

   postCobertura(coberturaForm: AddCobertura) {
      return this.http.post(this.baseUrl + 'Coberturas', coberturaForm);
   }

   deleteCob(coberturaId: number) {
      return this.http.delete(this.baseUrl + 'Coberturas/' + coberturaId);
   }

   editCob(cobForm: GetCoberturas) {
      return this.http.put(this.baseUrl + 'Coberturas', cobForm);
   }
}
