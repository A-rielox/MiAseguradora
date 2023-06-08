import { Injectable } from '@angular/core';
import { BehaviorSubject, map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { LoggedUsuario } from '../_models/LoggedUsuario';
import { HttpClient } from '@angular/common/http';
import { LoginModel } from '../_models/LoginModel';
import { RegisterModel } from '../_models/RegisterModel';

@Injectable({
   providedIn: 'root',
})
export class AccountService {
   baseUrl = environment.apiUrl;

   private currentUserSource = new BehaviorSubject<LoggedUsuario | null>(null);
   currentUser$ = this.currentUserSource.asObservable();

   constructor(private http: HttpClient) {}

   login(loginModel: LoginModel) {
      return this.http
         .post<LoggedUsuario>(this.baseUrl + 'account/login', loginModel)
         .pipe(
            map((usuario) => {
               this.setCurrentUser(usuario);
            })
         );
   }

   logout() {
      localStorage.removeItem('user');
      this.currentUserSource.next(null);
   }

   register(model: RegisterModel) {
      // estoy pasando el confirmPass
      return this.http
         .post<LoggedUsuario>(this.baseUrl + 'account/register', model)
         .pipe(
            map((usuario) => {
               if (usuario) {
                  this.setCurrentUser(usuario);
               }

               return usuario;
            })
         );
   }

   setCurrentUser(logUser: LoggedUsuario) {
      localStorage.setItem('user', JSON.stringify(logUser));
      this.currentUserSource.next(logUser);
   }
}
