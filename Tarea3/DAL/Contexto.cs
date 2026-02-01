using Microsoft.EntityFrameworkCore;
using Tarea3.Models;

namespace Tarea3.DAL;

public sealed class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }

    public DbSet<TiposPuntos> TiposPuntos => Set<TiposPuntos>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var e = modelBuilder.Entity<TiposPuntos>();

        e.ToTable("TiposPuntos");

        e.HasKey(x => x.TipoId);

        e.Property(x => x.TipoId).HasColumnName("TipoId");
        e.Property(x => x.Nombre).HasColumnName("Nombre").IsRequired().HasMaxLength(100);
        e.Property(x => x.Descripcion).HasColumnName("Descripcion").IsRequired().HasMaxLength(300);
        e.Property(x => x.ValorPuntos).HasColumnName("ValorPuntos").IsRequired();
        e.Property(x => x.Color).HasColumnName("Color").IsRequired().HasMaxLength(30);
        e.Property(x => x.Icono).HasColumnName("Icono").IsRequired().HasMaxLength(60);
        e.Property(x => x.Activo).HasColumnName("Activo").IsRequired();

        e.HasIndex(x => x.Nombre).IsUnique();
    }
}
