using Tarea2.Domain.Entities;

namespace Tarea2.Application.Interfaces
{
    public interface IAsignaturaService
    {
        Task<List<Asignatura>> GetAllAsync(string filtro = "");
        Task<Asignatura?> GetByIdAsync(int id);
        Task AddAsync(Asignatura asignatura);
        Task UpdateAsync(Asignatura asignatura);
        Task DeleteAsync(int id);
        Task<bool> NombreExisteAsync(string nombre, int? idExcluido = null);
    }
}
