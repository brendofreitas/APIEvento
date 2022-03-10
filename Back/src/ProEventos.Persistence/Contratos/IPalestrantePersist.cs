using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contratos
{
    public interface IPalestrantePersist
    {

        //PALESTRANTES

        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string Nome, bool IncludeEventos);
        Task<Palestrante[]> GetAllPalestrantesAsync(bool IncludeEventos);
        Task<Palestrante> GetPalestranteByIdAsync(int PalestranteId, bool IncludeEventos);
    }
}