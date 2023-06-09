import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { CotizarComponent } from './cotizar/cotizar.component';
import { PolizasComponent } from './polizas/polizas.component';
import { AuthGuard } from './_guards/auth.guard';

const routes: Routes = [
   { path: '', component: HomeComponent },
   {
      path: '',
      runGuardsAndResolvers: 'always',
      canActivate: [AuthGuard],
      children: [
         { path: 'cotizar', component: CotizarComponent },
         { path: 'polizas', component: PolizasComponent },
         // { path: 'members/edit', component: MemberEditComponent },
         // { path: 'members/:username', component: MemberDetailComponent },
         // { path: 'posts', component: PostsComponent },
         // { path: 'likes', component: LikesComponent },
         // { path: 'messages', component: MessagesComponent },
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
