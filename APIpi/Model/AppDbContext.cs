﻿using Microsoft.EntityFrameworkCore;

namespace APIpi.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Locacion> Locaciones { get; set; }

        // Agreagar clase que representa cada tabla en el folder de Model
        // Agregar public DbSet<NombreDeLaClase> NombreDeLaTabla { get; set; } aqui por cada tabla
    }
}
