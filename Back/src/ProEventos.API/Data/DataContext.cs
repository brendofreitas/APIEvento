using Microsoft.EntityFrameworkCore;
using ProEventos.API.models;

namespace ProEventos.API.Data
{
    public class DataContext : DbContext 
    {

        public DataContext(DbContextOptions<DataContext> option): base(option) { }
        public DbSet<Evento> Eventos { get; set; }
    }
}