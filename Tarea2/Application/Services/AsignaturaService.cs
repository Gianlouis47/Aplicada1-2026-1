using Tarea2.Domain.Entities;
using Tarea2.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Tarea2.Application.Services;

public class AsignaturaService
{
    private readonly ApplicationDbContext context;

    public AsignaturaService(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task CrearAsync(Asignatura asignatura)
    {
        context.Asignaturas.Add(asignatura);
        await context.SaveChangesAsync();
    }

    public async Task<Asignatura?> ObtenerPorIdAsync(int id)
    {
        return await context.Asignaturas.FindAsync(id);
    }

    public async Task ActualizarAsync(Asignatura asignatura)
    {
        context.Asignaturas.Update(asignatura);
        await context.SaveChangesAsync();
    }

    public async Task<List<Asignatura>> ListarAsync()
    {
        return await context.Asignaturas.ToListAsync();
    }
}
