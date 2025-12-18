using MatriculaEscolarIPTC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MatriculaEscolarIPTC.Data;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Estudiante> Estudiantes => Set<Estudiante>();
    public DbSet<Profesor> Profesores => Set<Profesor>();
    public DbSet<Materia> Materias => Set<Materia>();
    public DbSet<Grupo> Grupos => Set<Grupo>();
    public DbSet<Horario> Horarios => Set<Horario>();
    public DbSet<Matricula> Matriculas => Set<Matricula>();
    public DbSet<MatriculaDetalle> MatriculaDetalles => Set<MatriculaDetalle>();

    protected override void OnModelCreating(ModelBuilder b)
    {
        base.OnModelCreating(b);

        b.Entity<Materia>()
            .HasIndex(x => x.Codigo).IsUnique();

        b.Entity<Estudiante>()
            .HasIndex(x => x.Cedula).IsUnique();

        b.Entity<Profesor>()
            .HasIndex(x => x.Cedula).IsUnique();

        b.Entity<Grupo>()
            .HasOne(g => g.Materia).WithMany()
            .HasForeignKey(g => g.MateriaId)
            .OnDelete(DeleteBehavior.Restrict);

        b.Entity<Grupo>()
            .HasOne(g => g.Profesor).WithMany()
            .HasForeignKey(g => g.ProfesorId)
            .OnDelete(DeleteBehavior.Restrict);

        b.Entity<Horario>()
            .Property(x => x.HoraInicio)
            .HasConversion(
                v => v.ToTimeSpan(),
                v => TimeOnly.FromTimeSpan(v));

        b.Entity<Horario>()
            .Property(x => x.HoraFin)
            .HasConversion(
                v => v.ToTimeSpan(),
                v => TimeOnly.FromTimeSpan(v));

        b.Entity<Horario>()
            .HasOne(h => h.Grupo)
            .WithMany(g => g.Horarios)
            .HasForeignKey(h => h.GrupoId);

        b.Entity<MatriculaDetalle>()
            .HasOne(d => d.Grupo)
            .WithMany(g => g.Matriculas)
            .HasForeignKey(d => d.GrupoId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
