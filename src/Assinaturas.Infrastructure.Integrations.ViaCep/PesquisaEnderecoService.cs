using Assinaturas.Application.Enderecos.PesquisarPorCep;
using Assinaturas.Infrastructure.Integrations.ViaCep.Core;
using Assinaturas.SharedKernel.Results;
using Polly;
using RestSharp;
using System.Text.Json;

namespace Assinaturas.Infrastructure.Integrations.ViaCep;

public sealed class PesquisaEnderecoService : IPesquisaEnderecoService
{
    private static JsonSerializerOptions serializerOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
    private readonly ViaCepIntegrationSettings _viaCepIntegrationSettings;

    public PesquisaEnderecoService(ViaCepIntegrationSettings viaCepIntegrationSettings)
    {
        _viaCepIntegrationSettings = viaCepIntegrationSettings;
    }

    public async Task<Result<EnderecoDto, int>> PesquisarPorCepAsync(string cep, CancellationToken cancellationToken = default)
    {
        RestResponse response;
        var requestOptions = new RestClientOptions(_viaCepIntegrationSettings.BaseUrl)
        {
            ThrowOnAnyError = true,
            MaxTimeout = _viaCepIntegrationSettings.RequestTimeoutInSecs * 1000
        };
        using var client = new RestClient(requestOptions);
        var request = new RestRequest(string.Format(_viaCepIntegrationSettings.RouteTemplate, cep));

        return await Policy<Result<EnderecoDto, int>>
            .Handle<HttpRequestException>()
            .Or<TaskCanceledException>()
            .Or<IOException>()
            .WaitAndRetryAsync(_viaCepIntegrationSettings.RetryAttemptsMaxCount, count => TimeSpan.FromSeconds(Math.Pow(2, count) + Random.Shared.NextDouble()))
            .ExecuteAsync(async () =>
            {
                response = await client.ExecuteGetAsync(request, cancellationToken);

                try
                {
                    var deserializedResponse = JsonSerializer.Deserialize<Endereco>(response.Content!, serializerOptions)!;

                    return deserializedResponse.MapToDto();
                }
                catch (Exception)
                {
                    return (int)PesquisarPorCepErrorCodes.FalhaIntegracaoServicoBusca;
                }
            });
    }
}