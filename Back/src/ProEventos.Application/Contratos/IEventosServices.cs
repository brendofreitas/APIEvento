using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Application.Contratos
{
    public interface IEventoServices
    {
        Task<Evento> AddEventos(Evento model);
        Task<Evento> UpdateEventos(int eventoId, Evento model);
        Task<bool> DeleteEventos(int eventoId);

        Task<Evento[]> GetAllEventosAsync(bool IncludePalestrantes = false);
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool IncludePalestrantes = false);
        Task<Evento> GetEventoByIdAsync(int eventoId, bool IncludePalestrantes = false);
    }
}