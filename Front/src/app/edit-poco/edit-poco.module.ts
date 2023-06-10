import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EditPocoComponent } from './edit-poco.component';
import { CoberturasComponent } from './coberturas/coberturas.component';
import { PrimeModule } from '../_prime/prime/prime.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from '../_shared/shared.module';
import { LeftTextComponent } from './left-text/left-text.component';

@NgModule({
   declarations: [EditPocoComponent, CoberturasComponent, LeftTextComponent],
   imports: [
      CommonModule,
      PrimeModule,
      SharedModule,
      ReactiveFormsModule,
      FormsModule,
   ],
})
export class EditPocoModule {}
