using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using metaenlace_citas_medicas.Entities;

namespace metaenlace_citas_medicas.Repositories
{
    public class citasMedicasDbContext : DbContext
    {

        public citasMedicasDbContext(DbContextOptions<citasMedicasDbContext> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Paciente> Pacientes { get; set; }

        public DbSet<Medico> Medicos { get; set; }

        public DbSet<Cita> Citas { get; set; }

        public DbSet<Diagnostico> Diagnosticos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("USUARIOS");
            modelBuilder.Entity<Paciente>().ToTable("PACIENTES");
            modelBuilder.Entity<Medico>().ToTable("MEDICOS");
        }
    }
}
