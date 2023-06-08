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
   ],
   providers: [],
   bootstrap: [AppComponent],
})
export class AppModule {}
