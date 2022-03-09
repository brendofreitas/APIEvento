using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence
{
    public interface IProEventosPersistence
    {

        //GERAL
         void Add<T>(T entity) where T: class;

         void Update<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         void DeleteRange<T>(T[] entity) where T: class;

        Task<bool> SaveChangesAsync();

        //EVENTOS

        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool IncludePalestrantes);
        Task<Evento[]> GetAllEventosAsync(bool IncludePalestrantes);
        Task<Evento> GetEventoByIdAsync(int EventoId, bool IncludePalestrantes);

        //PALESTRANTES

        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string Nome, bool IncludeEventos);
        Task<Palestrante[]> GetAllPalestrantesAsync(bool IncludeEventos);
        Task<Palestrante> GetPalestranteByIdAsync(int PalestranteId, bool IncludeEventos);
    }
}