import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { LoggedUsuario } from '../_models/LoggedUsuario';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs';

@Injectable({
   providedIn: 'root',
})
export class UsuariosService {
   baseUrl = environment.apiUrl;
   usuarios: LoggedUsuario[] = [];

   constructor(private http: HttpClient) {}

   getUsuarios() {
      return this.http
         .get<LoggedUsuario[]>(this.baseUrl + 'Usuarios')
         .pipe(map((res) => (this.usuarios = res)));
   }
}
