import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { NavComponent } from './nav/nav.component';
import { PrimeModule } from './_prime/prime/prime.module';
import { LoginModalComponent } from './nav/login-modal/login-modal.component';
import { HomeModule } from './home/home.module';
import { NotificationsModule } from './notifications/notifications.module';
import { CotizarModule } from './cotizar/cotizar.module';
import { PolizasModule } from './polizas/polizas.module';
import { ErrorInterceptor } from './_interceptors/error.interceptor';
import { JwtInterceptor } from './_interceptors/jwt.interceptor';

@NgModule({
   declarations: [AppComponent, NavComponent, LoginModalComponent],
   imports: [
      BrowserModule,
      AppRoutingModule,
      BrowserAnimationsModule,
      HttpClientModule,
      FormsModule,
      ReactiveFormsModule,
      //
      PrimeModule,
      HomeModule,
      NotificationsModule,
      CotizarModule,
      PolizasModule,
   ],
   providers: [
      { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
      { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
   ],
   bootstrap: [AppComponent],
})
export class AppModule {}
