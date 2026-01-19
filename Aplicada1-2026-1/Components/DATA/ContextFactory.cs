using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Aplicada1_2026_1.Data
{
    public class ContextFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            optionsBuilder.UseSqlServer(
                "Server=Tareas-Aplicada1-2026.mssql.somee.com;Database=Tareas-Aplicada1-2026;User Id=Gianlouis47_SQLLogin_1;Password=r3oeu23k7y;TrustServerCertificate=True;Encrypt=True;MultipleActiveResultSets=True"
            );

            return new Context(optionsBuilder.Options);
        }
    }
}

