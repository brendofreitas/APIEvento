using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contratos
{
    public interface IEventoPersist
    {

        
        //EVENTOS

        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool IncludePalestrantes = false);
        Task<Evento[]> GetAllEventosAsync(bool IncludePalestrantes = false);
        Task<Evento> GetEventoByIdAsync(int EventoId, bool IncludePalestrantes = false);



    }
}