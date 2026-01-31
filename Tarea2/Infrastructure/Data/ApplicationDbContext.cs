using Microsoft.EntityFrameworkCore;
using Tarea2.Domain.Entities;

namespace Tarea2.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Asignatura> Asignaturas => Set<Asignatura>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Asignatura>()
            .ToTable("Asignaturas");

        modelBuilder.Entity<Asignatura>()
            .HasIndex(x => x.Nombre)
            .IsUnique();
    }
}
