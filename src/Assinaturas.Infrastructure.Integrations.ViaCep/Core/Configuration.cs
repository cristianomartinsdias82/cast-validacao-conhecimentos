using Assinaturas.Application.Enderecos.PesquisarPorCep;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Assinaturas.Infrastructure.Integrations.ViaCep.Core;

public static class Configuration
{
    public static IServiceCollection AddViaCepIntegrationClient(this IServiceCollection services, IConfiguration configuration)
    {
        services.TryAddScoped<IPesquisaEnderecoService, PesquisaEnderecoService>();

        return services;
    }
}