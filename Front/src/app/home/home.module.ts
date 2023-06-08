import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';
import { ModalRegistroComponent } from './modal-registro/modal-registro.component';
import { PrimeModule } from '../_prime/prime/prime.module';
import { SharedModule } from '../_shared/shared.module';
import { ReactiveFormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button';

@NgModule({
   declarations: [HomeComponent, ModalRegistroComponent],
   imports: [
      CommonModule,
      PrimeModule,
      SharedModule,
      ReactiveFormsModule,
      ButtonModule,
   ],
   exports: [HomeComponent],
})
export class HomeModule {}
