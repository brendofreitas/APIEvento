﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Data;
using ProEventos.API.models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly DataContext context;

        public EventosController(DataContext context)
        {
            this.context = context;

        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return context.Eventos;
        }
        [HttpGet("{id}")]
        public Evento GetById(int id)
        {
            return context.Eventos.FirstOrDefault(
                evento => evento.EventoId == id);

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