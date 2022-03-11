using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contextos
{
    public class ProEventosContext : DbContext 
    {

        public ProEventosContext(DbContextOptions<ProEventosContext> option)
        : base(option) { }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<Palestrante> Palestrantes { get; set; }
        public DbSet<PalestranteEvento> PalestrantesEventos { get; set; }
        public DbSet<RedeSocial> RedesSociais { get; set; }

            // OnModelCreating sendo utilizando para a conexão de duas chaves com o entity
            // Foi criado uma Classe Palestrante Evento para receber as duas chaves
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<PalestranteEvento>()
            //haskey fez a criação e associação do evento com o palestrante atraves do id.
            .HasKey(PE => new {PE.EventoId, PE.PalestranteId});


            // utilizando o modelbuild para dizer ao entity que quando ele deletar o evento
            // ele delete também as redes sociais desse evento.
            modelBuilder.Entity<Evento>()
            .HasMany(e => e.RedeSociais)
            .WithOne(rs => rs.Evento)
            // usando o modo cascade como uma cascata deletou o primeiro faça as instruções a baixo
            .OnDelete(DeleteBehavior.Cascade);

            // usando o model build para dizer ao entity que quando deletar o Palestrante
            // ele delete também as redes sociais associadas ao palestrante.
             modelBuilder.Entity<Palestrante>()
            .HasMany(e => e.RedesSociais)
            // usando o modo cascade como uma cascata deletou o primeiro faça as instruções a baixo
            .WithOne(rs => rs.Palestrante)
            .OnDelete(DeleteBehavior.Cascade);
            
        }
    }
}