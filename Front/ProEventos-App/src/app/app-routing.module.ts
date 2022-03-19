import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EventosComponent } from './components/eventos/eventos.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { PalestrantesComponent } from './components/palestrantes/palestrantes.component';
import { contatosComponent } from './components/contatos/contatos.component';
import { PerfilComponent } from './components/perfil/perfil.component';
import { EventoDetalheComponent } from './components/eventos/evento-detalhe/evento-detalhe.component';
import { EventoListaComponent } from './components/eventos/evento-lista/evento-lista.component';

const routes: Routes = [
  {path: 'eventos' ,redirectTo:'eventos/lista'},
  {
    path: 'eventos',
    component: EventosComponent,
    children: [
      {path: 'detalhe/:id', component: EventoDetalheComponent },
      {path: 'detalhe', component: EventoDetalheComponent },
      {path: 'lista', component: EventoListaComponent },
    ],
  },
  { path: 'dasboard', component: DashboardComponent},
  { path: 'palestrantes', component: PalestrantesComponent},
  { path: 'perfil', component: PerfilComponent},
  { path: 'contatos', component: contatosComponent},
  { path: '**', redirectTo : 'dasboard', pathMatch : 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
