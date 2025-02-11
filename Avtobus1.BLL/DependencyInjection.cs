using Avtobus1.BLL.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Avtobus1.BLL;

public static class DependencyInjection
{
    public static void RegisterBLL(this IServiceCollection services, IConfiguration Configuration)
    {
        services.AddScoped<IShortUrlService, ShortUrlService>();
    }
}
