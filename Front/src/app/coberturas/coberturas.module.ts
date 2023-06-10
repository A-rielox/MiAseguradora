import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CoberturaComponent } from './cobertura.component';
import { PrimeModule } from '../_prime/prime/prime.module';
import { SharedModule } from '../_shared/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CoberturaListComponent } from './cobertura-list/cobertura-list.component';
import { EditCobsComponent } from './edit-cobs/edit-cobs.component';

@NgModule({
   declarations: [CoberturaComponent, CoberturaListComponent, EditCobsComponent],
   imports: [CommonModule, SharedModule, PrimeModule, ReactiveFormsModule],
   exports: [CoberturaComponent],
})
export class CoberturasModule {}
