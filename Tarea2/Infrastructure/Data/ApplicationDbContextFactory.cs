using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Tarea2.Infrastructure.Data;

public sealed class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        var cs = config.GetConnectionString("SqlContStr");

        if (string.IsNullOrWhiteSpace(cs))
            throw new InvalidDataException("Connection string 'SqlContStr' no encontrada en appsettings.json.");

        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlServer(cs)
            .Options;

        return new ApplicationDbContext(options);
    }
}


