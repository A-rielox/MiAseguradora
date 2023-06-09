import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EditPocoComponent } from './edit-poco.component';
import { CoberturasComponent } from './coberturas/coberturas.component';



@NgModule({
  declarations: [
    EditPocoComponent,
    CoberturasComponent
  ],
  imports: [
    CommonModule
  ]
})
export class EditPocoModule { }
