import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PolizasComponent } from './polizas.component';
import { SharedModule } from '../_shared/shared.module';
import { PrimeModule } from '../_prime/prime/prime.module';
import { ButtonModule } from 'primeng/button';

@NgModule({
   declarations: [PolizasComponent],
   imports: [CommonModule, SharedModule, PrimeModule, ButtonModule],
   exports: [PolizasComponent],
})
export class PolizasModule {}
