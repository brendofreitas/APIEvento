using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Application.Contratos
{
    public interface IEventoServices
    {
        //Adicinanddo evento e recebendo por parametro todos os dados de um evento
        Task<Evento> AddEventos(Evento model);
        //Fazendo Update de um evento passando o Id do evento e os dados a ser atualizados
        Task<Evento> UpdateEventos(int eventoId, Evento model);
        //deletando um evento passando o Id do evento por parametro, e dizendo se e bool v ou f
        Task<bool> DeleteEventos(int eventoId);

        
        Task<Evento[]> GetAllEventosAsync(bool IncludePalestrantes = false);
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool IncludePalestrantes = false);
        Task<Evento> GetEventoByIdAsync(int eventoId, bool IncludePalestrantes = false);
    }
}