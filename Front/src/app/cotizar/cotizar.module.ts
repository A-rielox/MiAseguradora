import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CotizarComponent } from './cotizar.component';
import { PrimeModule } from '../_prime/prime/prime.module';
import { SharedModule } from '../_shared/shared.module';

@NgModule({
   declarations: [CotizarComponent],
   imports: [CommonModule, PrimeModule, SharedModule],
   exports: [CotizarComponent],
})
export class CotizarModule {}
