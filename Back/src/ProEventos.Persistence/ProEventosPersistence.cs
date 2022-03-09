using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;

namespace ProEventos.Persistence
{
    public class ProEventosPersistence : IProEventosPersistence
    {
        private readonly ProEventosContext _context;

        public ProEventosPersistence(ProEventosContext context)
        {
            _context = context;


        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }


        public async Task<Evento[]> GetAllEventosAsync(bool IncludePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
            .Include(e => e.Lotes)
            .Include(e => e.RedeSociais);
            if (IncludePalestrantes)
            {
                query = query.Include(e => e.PalestrantesEventos)
                .ThenInclude(pe => pe.Palestrante);
            }
            query = query.OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool IncludePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
            .Include(e => e.Lotes)
            .Include(e => e.RedeSociais);
            if (IncludePalestrantes)
            {
                query = query.Include(e => e.PalestrantesEventos)
                .ThenInclude(pe => pe.Palestrante);
            }
            query = query.OrderBy(e => e.Id)
            .Where(e=> e.Tema.ToLower()
            .Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }
        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool IncludePalestrantes = false)
        {
             IQueryable<Evento> query = _context.Eventos
            .Include(e => e.Lotes)
            .Include(e => e.RedeSociais);

            if (IncludePalestrantes)
            {
                query = query.Include(e => e.PalestrantesEventos)
                .ThenInclude(pe => pe.Palestrante);
            }
            query = query.OrderBy(e => e.Id)
            .Where(e=> e.Id == eventoId);

            return await query.FirstOrDefaultAsync();
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
            query = query.OrderBy(p => p.Id);
            

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
            query = query.OrderBy(e => e.Id)
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
            query = query.OrderBy(e => e.Id)
            .Where(p => p.Id == palestranteId);
            

            return await query.FirstOrDefaultAsync();
        }


    }
}