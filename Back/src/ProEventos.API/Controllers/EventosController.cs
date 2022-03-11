using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.Persistence;
using ProEventos.Domain;
using ProEventos.Persistence.Contextos;
using ProEventos.Application.Contratos;
using Microsoft.AspNetCore.Http;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {

        private readonly IEventoServices _eventoServices;

        public EventosController(IEventoServices eventoServices)
        {
            _eventoServices = eventoServices;


        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var eventos = await _eventoServices.GetAllEventosAsync(true);
                if(eventos == null) return NotFound("Evento não encontrado");

                return Ok(eventos);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                 $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
             try
            {
                var evento = await _eventoServices.GetEventoByIdAsync(id,true);
                if(evento == null) return NotFound("Evento Por ID não encontrado");

                return Ok(evento);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                 $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }
        }

        [HttpGet("{tema}/tema")]
        public async Task<IActionResult> GetByTema(string tema)
        {
             try
            {
                var evento = await _eventoServices.GetAllEventosByTemaAsync(tema,true);
                if(evento == null) return NotFound("Eventos por Tema não encontrado");

                return Ok(evento);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                 $"Eventos por Tema não encontrados. Erro: {ex.Message}");
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post(Evento model)
        {
             try
            {
                var evento = await _eventoServices.AddEventos(model);
                if(evento == null) return BadRequest("Erro ao tentar Adicionar Evento.");

                return Ok(evento);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                 $"Erro ao tentar adicionar o eventos. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Put(int id, Evento model)
        {
            try
            {
                var evento = await _eventoServices.UpdateEventos(id,model);
                if(evento == null) return BadRequest("Erro ao tentar Atualizar Evento.");

                return Ok(evento);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                 $"Erro ao tentar Atualizar o  Evento. erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (await _eventoServices.DeleteEventos(id))
                
                    return Ok("Deletado");
                    else
                    return BadRequest("Evento não deletado");
                    
                
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                 $"Erro ao tentar deletar eventos. Erro: {ex.Message}");
            }
        }
    }
}
