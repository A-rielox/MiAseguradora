import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { CotizarComponent } from './cotizar/cotizar.component';
import { PolizasComponent } from './polizas/polizas.component';
import { AuthGuard } from './_guards/auth.guard';
import { EditPocoComponent } from './edit-poco/edit-poco.component';
import { CoberturaComponent } from './coberturas/cobertura.component';
import { EditCobsComponent } from './coberturas/edit-cobs/edit-cobs.component';

const routes: Routes = [
   { path: '', component: HomeComponent },
   {
      path: '',
      runGuardsAndResolvers: 'always',
      canActivate: [AuthGuard],
      children: [
         { path: 'cotizar', component: CotizarComponent },
         { path: 'polizas', component: PolizasComponent },
         { path: 'edit-poco', component: EditPocoComponent },
         { path: 'cobertura', component: CoberturaComponent },
         { path: 'edit-cob', component: EditCobsComponent },
      ],
   },
   // { path: 'not-found', component: NotFoundComponent },
   // { path: '**', component: NotFoundComponent, pathMatch: 'full' },
];

@NgModule({
   imports: [RouterModule.forRoot(routes)],
   exports: [RouterModule],
})
export class AppRoutingModule {}
