using Microsoft.EntityFrameworkCore;
using Tarea2.Domain.Entities;
using Tarea2.Infrastructure.Data;

namespace Tarea2.Application.Services;

public class AsignaturaService
{
    private readonly ApplicationDbContext db;

    public AsignaturaService(ApplicationDbContext db)
    {
        this.db = db;
    }

    public async Task<List<Asignatura>> ListarAsync(string? filtroCampo, string? busqueda)
    {
        var q = db.Asignaturas.AsNoTracking().AsQueryable();

        if (!string.IsNullOrWhiteSpace(busqueda))
        {
            var term = busqueda.Trim();

            if (string.IsNullOrWhiteSpace(filtroCampo) || filtroCampo == "Nombre")
                q = q.Where(x => x.Nombre.Contains(term));
            else if (filtroCampo == "Codigo")
                q = q.Where(x => x.Codigo.Contains(term));
            else if (filtroCampo == "Aula")
                q = q.Where(x => x.Aula.Contains(term));
            else if (filtroCampo == "Creditos")
            {
                if (int.TryParse(term, out var c))
                    q = q.Where(x => x.Creditos == c);
                else
                    q = q.Where(_ => false);
            }
            else
                q = q.Where(x => x.Nombre.Contains(term));
        }

        return await q.OrderBy(x => x.AsignaturaId).ToListAsync();
    }

    public async Task<Asignatura?> ObtenerPorIdAsync(int id)
        => await db.Asignaturas.FindAsync(id);

    public async Task CrearAsync(Asignatura a)
    {
        if (await db.Asignaturas.AnyAsync(x => x.Nombre == a.Nombre))
            throw new InvalidOperationException("No se permite registrar dos asignaturas con el mismo Nombre.");

        db.Asignaturas.Add(a);
        await db.SaveChangesAsync();
    }

    public async Task ActualizarAsync(Asignatura a)
    {
        if (await db.Asignaturas.AnyAsync(x => x.Nombre == a.Nombre && x.AsignaturaId != a.AsignaturaId))
            throw new InvalidOperationException("No se permite registrar dos asignaturas con el mismo Nombre.");

        db.Asignaturas.Update(a);
        await db.SaveChangesAsync();
    }

    public async Task EliminarAsync(int id)
    {
        var entity = await db.Asignaturas.FindAsync(id);
        if (entity is null) return;

        db.Asignaturas.Remove(entity);
        await db.SaveChangesAsync();
    }
}
