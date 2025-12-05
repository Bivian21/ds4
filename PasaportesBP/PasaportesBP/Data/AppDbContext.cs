using Microsoft.EntityFrameworkCore;
using PasaportesBP.Models;

namespace PasaportesBP.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Solicitante> Solicitantes { get; set; }
        public DbSet<Pasaporte> Pasaportes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Solicitante>().ToTable("BP_Solicitante");
            modelBuilder.Entity<Pasaporte>().ToTable("BP_Pasaporte");

            base.OnModelCreating(modelBuilder);
        }
    }
}
