import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EventosComponent } from './components/eventos/eventos.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { PalestrantesComponent } from './components/palestrantes/palestrantes.component';
import { contatosComponent } from './components/contatos/contatos.component';
import { PerfilComponent } from './components/perfil/perfil.component';

const routes: Routes = [
  { path: 'eventos', component: EventosComponent},
  { path: 'dasboard', component: DashboardComponent},
  { path: 'palestrantes', component: PalestrantesComponent},
  { path: 'perfil', component: PerfilComponent},
  { path: 'contatos', component: contatosComponent},
  { path: '', redirectTo : 'dasboard', pathMatch : 'full'},
  { path: '**', redirectTo : 'dasboard', pathMatch : 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
