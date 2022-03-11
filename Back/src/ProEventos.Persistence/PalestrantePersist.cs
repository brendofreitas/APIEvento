using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contextos;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence
{
    public class PalestrantePersistence : IPalestrantePersist
    {
        private readonly ProEventosContext _context;

        public PalestrantePersistence(ProEventosContext context)
        {
            _context = context;


        }
       
        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool IncludeEventos = false)
        {
             IQueryable<Palestrante> query = _context.Palestrantes
            .Include(p => p.RedesSociais);

            if (IncludeEventos)
            {
                query = query.Include(p => p.PalestrantesEventos)
                .ThenInclude(pe => pe.Evento);
            }
            query = query.AsNoTracking().OrderBy(p => p.Id);
            

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool IncludeEventos)
        {
            
             IQueryable<Palestrante> query = _context.Palestrantes
            .Include(e => e.RedesSociais);

            if (IncludeEventos)
            {
                query = query.Include(e => e.PalestrantesEventos)
                .ThenInclude(pe => pe.Evento);
            }
            query = query.AsNoTracking().OrderBy(e => e.Id)
            .Where(p => p.Nome.ToLower()
            .Contains(nome.ToLower()));
            

            return await query.ToArrayAsync();
        }



        public async Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool IncludeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
            .Include(e => e.RedesSociais);

            if (IncludeEventos)
            {
                query = query.Include(e => e.PalestrantesEventos)
                .ThenInclude(pe => pe.Evento);
            }
            query = query.AsNoTracking().OrderBy(e => e.Id)
            .Where(p => p.Id == palestranteId);
            

            return await query.FirstOrDefaultAsync();
        }


    }
}