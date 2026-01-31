using Microsoft.EntityFrameworkCore;
using Tarea3.DAL;
using Tarea3.Models;

namespace Tarea3.Services;

public sealed class TiposPuntosService
{
    private readonly IDbContextFactory<Contexto> dbFactory;

    public TiposPuntosService(IDbContextFactory<Contexto> dbFactory)
    {
        this.dbFactory = dbFactory;
    }

    public async Task<bool> Guardar(TiposPuntos entity)
    {
        if (await Existe(entity.TipoId))
            return await Modificar(entity);

        return await Insertar(entity);
    }

    public async Task<bool> Existe(int tipoId)
    {
        await using var db = await dbFactory.CreateDbContextAsync();
        return await db.TiposPuntos.AnyAsync(x => x.TipoId == tipoId);
    }

    public async Task<bool> Insertar(TiposPuntos entity)
    {
        await using var db = await dbFactory.CreateDbContextAsync();

        var dup = await db.TiposPuntos.AnyAsync(x => x.Nombre == entity.Nombre);
        if (dup)
            throw new InvalidOperationException("Duplicate Name is not allowed.");

        db.TiposPuntos.Add(entity);
        return await db.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(TiposPuntos entity)
    {
        await using var db = await dbFactory.CreateDbContextAsync();

        var dup = await db.TiposPuntos.AnyAsync(x => x.Nombre == entity.Nombre && x.TipoId != entity.TipoId);
        if (dup)
            throw new InvalidOperationException("Duplicate Name is not allowed.");

        db.TiposPuntos.Update(entity);
        return await db.SaveChangesAsync() > 0;
    }

    public async Task<TiposPuntos?> Buscar(int tipoId)
    {
        await using var db = await dbFactory.CreateDbContextAsync();
        return await db.TiposPuntos.AsNoTracking().FirstOrDefaultAsync(x => x.TipoId == tipoId);
    }

    public async Task<bool> Eliminar(int tipoId)
    {
        await using var db = await dbFactory.CreateDbContextAsync();

        var entity = await db.TiposPuntos.FindAsync(tipoId);
        if (entity is null) return false;

        db.TiposPuntos.Remove(entity);
        return await db.SaveChangesAsync() > 0;
    }

    public async Task<List<TiposPuntos>> Listar()
    {
        await using var db = await dbFactory.CreateDbContextAsync();
        return await db.TiposPuntos.AsNoTracking().OrderBy(x => x.TipoId).ToListAsync();
    }
}
