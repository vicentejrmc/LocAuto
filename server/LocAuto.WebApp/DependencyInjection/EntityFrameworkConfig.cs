using Microsoft.EntityFrameworkCore;

namespace LocAuto.WebApp.DependencyInjection;

public static class EntityFrameworkConfig
{
    public static IServiceCollection AddEntityFrameworkConfig
        (this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<LocAuto.Infraestrutura.Compartilhado.LocAutoDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));


        return services;
    }
}
