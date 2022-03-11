using System;
using System.Threading.Tasks;
using ProEventos.Application.Contratos;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Application
{
    public class EventoService : IEventoServices
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IEventoPersist _eventoPersist;

        public EventoService(IGeralPersist geralPersist, IEventoPersist eventoPersist)
        {
            _eventoPersist = eventoPersist;
            _geralPersist = geralPersist;

        }
        public async Task<Evento> AddEventos(Evento model)
        {
            try
            {
                _geralPersist.Add<Evento>(model);
                if(await _geralPersist.SaveChangesAsync())
                {
                   return await _eventoPersist.GetEventoByIdAsync(model.Id, false);    
                }
                return null;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

         public async Task<Evento> UpdateEventos(int EventoId, Evento model)
        {
            try
            {
                var evento= await _eventoPersist.GetEventoByIdAsync(EventoId, false);
                if (evento == null) return null;

                model.Id = evento.Id;

                _geralPersist.Update(model);
                 if(await _geralPersist.SaveChangesAsync())
                {
                   return await _eventoPersist.GetEventoByIdAsync(model.Id, false);    
                }
                return null;
                
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }

        }

        public async Task<bool> DeleteEventos(int EventoId)
        {
            try
            {
                var evento= await _eventoPersist.GetEventoByIdAsync(EventoId, false);
                if (evento == null) throw new Exception("Evento não encontrado");

                _geralPersist.Delete<Evento>(evento);
                return await _geralPersist.SaveChangesAsync();
               
                
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }

            
        }

        public async Task<Evento[]> GetAllEventosAsync(bool IncludePalestrantes = false)
        {
            try
            {
                var eventos= await _eventoPersist.GetAllEventosAsync(IncludePalestrantes);
                if(eventos == null) return null;

                return eventos;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool IncludePalestrantes = false)
        {
             try
            {
                var eventos= await _eventoPersist.GetAllEventosByTemaAsync(tema,IncludePalestrantes);
                if(eventos == null) return null;

                return eventos;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool IncludePalestrantes = false)
        {
             try
            {
                var eventos= await _eventoPersist.GetEventoByIdAsync(eventoId,IncludePalestrantes);
                if(eventos == null) return null;

                return eventos;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

       
    }
}