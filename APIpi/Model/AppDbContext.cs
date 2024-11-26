using Microsoft.EntityFrameworkCore;

namespace APIpi.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Locacion> Locaciones { get; set; }
        public DbSet<ServiciosAdicionales> Servicios_Adicionales { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Eventos> Eventos { get; set; }
        public DbSet<Agenda> Agendas { get; set; }

        // Agreagar clase que representa cada tabla en el folder de Model
        // Agregar public DbSet<NombreDeLaClase> NombreDeLaTabla { get; set; } aqui por cada tabla
    }
}
