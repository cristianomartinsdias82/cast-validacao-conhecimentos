using Assinaturas.Domain.Assinaturas;
using Assinaturas.Infrastructure.Persistence.Ef.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Assinaturas.Infrastructure.Persistence.Ef.Core;

public static class Configuration
{
    public static IServiceCollection AddEfBasedPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AssinaturasDbContext>(options => options.UseSqlite(configuration["ConnectionStrings:AssinaturasDb"]));

        services.TryAddScoped<IContaRepository, ContaRepository>();

        return services;
    }
}