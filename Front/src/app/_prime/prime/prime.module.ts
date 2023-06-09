import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { StyleClassModule } from 'primeng/styleclass';

import { ButtonModule } from 'primeng/button';
import { MenubarModule } from 'primeng/menubar';
import { MenuModule } from 'primeng/menu';
import { DropdownModule } from 'primeng/dropdown';
import { AvatarModule } from 'primeng/avatar';
import { DialogModule } from 'primeng/dialog';
import { DynamicDialogModule } from 'primeng/dynamicdialog';
import { InputTextModule } from 'primeng/inputtext';
import { InputNumberModule } from 'primeng/inputnumber';
import { DividerModule } from 'primeng/divider';
import { TableModule } from 'primeng/table';
import { ConfirmPopupModule } from 'primeng/confirmpopup';
import { TooltipModule } from 'primeng/tooltip';

@NgModule({
   declarations: [],
   imports: [
      CommonModule,
      StyleClassModule,
      ButtonModule,
      MenubarModule,
      MenuModule,
      DropdownModule,
      AvatarModule,
      DialogModule,
      DynamicDialogModule,
      InputTextModule,
      InputNumberModule,
      DividerModule,
      TableModule,
      ConfirmPopupModule,
      TooltipModule,
   ],
   exports: [
      StyleClassModule,
      ButtonModule,
      MenubarModule,
      MenuModule,
      DropdownModule,
      AvatarModule,
      DialogModule,
      DynamicDialogModule,
      InputTextModule,
      InputNumberModule,
      DividerModule,
      TableModule,
      ConfirmPopupModule,
      TooltipModule,
   ],
})
export class PrimeModule {}
