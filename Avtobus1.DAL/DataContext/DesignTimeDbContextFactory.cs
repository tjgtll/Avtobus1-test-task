using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Avtobus1.DAL.DataContext;
internal class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<Avtobus1DbContext>
{
    public Avtobus1DbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json")
           .Build();

        var builder = new DbContextOptionsBuilder<Avtobus1DbContext>();
        builder.UseMySql(
            configuration.GetConnectionString("MyDbConnection"),
            new MySqlServerVersion(new Version(10, 3, 39))
        );

        return new Avtobus1DbContext(builder.Options);
    }
}