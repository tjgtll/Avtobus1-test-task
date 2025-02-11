using Avtobus1.DAL.Repositories.IRepositories;
using Avtobus1.DAL.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Avtobus1.DAL.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Avtobus1.DAL;
public static class DependencyInjection
{
    public static void RegisterDAL(this IServiceCollection services, IConfiguration Configuration)
    {
        services.AddDbContext<Avtobus1DbContext>(options =>
            options.UseMySql(
                Configuration.GetConnectionString("MyDbConnection"),
                new MySqlServerVersion(new Version(10, 3, 39))
            ),
            ServiceLifetime.Transient
        );

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
    }
}
