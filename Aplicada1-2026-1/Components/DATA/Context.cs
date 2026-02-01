using Microsoft.EntityFrameworkCore;
using Aplicada1_2026_1.Models;
using System.ComponentModel.DataAnnotations;

namespace Aplicada1_2026_1.Data
{

    public class Context : DbContext
    {
     
        public Context(DbContextOptions<Context> options)
            : base(options) { }

        public DbSet<Estudiante> Estudiantes => Set<Estudiante>();
    }
}
