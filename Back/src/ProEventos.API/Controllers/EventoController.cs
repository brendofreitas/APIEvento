using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        public IEnumerable <Evento> _evento =  new Evento[]
                    {
                            new Evento(){
                            EventoId = 1,
                            Tema = "Angular 11 e .Net 5",
                            Local = "Rio de Janeiro",
                            Lote = "1",
                            QtdPessoa = 250,
                            DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
                            ImagemURL = "foto.png"
                        },
                        new Evento()
                        {
                            EventoId = 2,
                            Tema = "Angular e suas novidades",
                            Local = "São Paulo",
                            Lote = "2",
                            QtdPessoa = 350,
                            DataEvento = DateTime.Now.AddDays(3).ToString("dd/MM/yyyy"),
                            ImagemURL = "imagem.png"
                        }
                    };

        public EventoController()
        {
           
        }

        [HttpGet]
        public IEnumerable <Evento> Get()
        {
            return _evento;
                         
        }
         [HttpGet("{id}")]
        public IEnumerable <Evento> GetById(int id)
        {
            return _evento.Where(_evento=> _evento.EventoId == id);
                         
        }

        [HttpPost("{id}")]
        public string Post(int id)
        {
            return $"Exemplo de Post com id = {id}";
        }

        [HttpPut("{id}")]

        public string Put()
        {
            return "Exemplo de put";
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return $"Tipo de delete com id= {id}";
        }
    }
}
