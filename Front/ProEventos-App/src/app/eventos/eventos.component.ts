
import { Component, OnInit } from '@angular/core';
import { Evento } from '../Models/Evento';
import { EventoService } from '../services/Evento.service';


@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos: Evento[] = [] ;
  public eventosFiltrados : Evento[] = [];
  larguraImagem: number = 150;
  margemImagem: number = 2;
  exibirImagem: boolean = true;
  private filtroListado: string = '';

  public get filtroLista(){
    return this.filtroListado;
  }
  public set filtroLista(value : string){
    this.filtroListado = value;
    this.eventosFiltrados = this.filtroListado ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }

  filtrarEventos(filtrarPor: string): Evento[]{
filtrarPor = filtrarPor.toLocaleLowerCase();
return this.eventos.filter((evento: any) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1)
}

  constructor(private eventoService : EventoService) { }

public  ngOnInit(): void {
    this.getEventos();
  }

 public alterarImagem() : void {
    this.exibirImagem = !this.exibirImagem;
  }

  //getEventos tem valor nenhum, estamos jogando o valor dentro de "eventos criado no valor any []"
  public getEventos(): void {
    //esta pegando acessando eventoservice onde tem um getEventos e dizendo que _eventos que e do tipo evento.
    // recebe o valor de eventoService.getEvento e passa para _eventos
   this.eventoService.getEventos().subscribe(
     (eventoResp: Evento[]) =>{
        this.eventos = eventoResp;
        this.eventosFiltrados = this.eventos;
    },
     error => console.log(error)
   );
  }

}
