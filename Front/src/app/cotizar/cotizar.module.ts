import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CotizarComponent } from './cotizar.component';
import { PrimeModule } from '../_prime/prime/prime.module';
import { SharedModule } from '../_shared/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LeftTextComponent } from './left-text/left-text.component';
import { RightFormComponent } from './right-form/right-form.component';
import { CoberturasComponent } from './coberturas/coberturas.component';

@NgModule({
   declarations: [
      CotizarComponent,
      LeftTextComponent,
      RightFormComponent,
      CoberturasComponent,
   ],
   imports: [
      CommonModule,
      PrimeModule,
      SharedModule,
      ReactiveFormsModule,
      FormsModule,
   ],
   exports: [CotizarComponent],
})
export class CotizarModule {}
