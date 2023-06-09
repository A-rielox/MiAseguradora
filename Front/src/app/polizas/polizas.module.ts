import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PolizasComponent } from './polizas.component';
import { SharedModule } from '../_shared/shared.module';
import { PrimeModule } from '../_prime/prime/prime.module';

@NgModule({
   declarations: [PolizasComponent],
   imports: [CommonModule, SharedModule, PrimeModule],
   exports: [PolizasComponent],
})
export class PolizasModule {}
