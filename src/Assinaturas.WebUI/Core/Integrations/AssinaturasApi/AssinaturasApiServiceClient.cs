using Assinaturas.WebUI.Models.Assinaturas;
using System.Text.Json;

namespace Assinaturas.WebUI.Core.Integrations.AssinaturasApi;

internal sealed class AssinaturasApiServiceClient : IAssinaturasApiServiceClient
{
    private readonly HttpClient _httpClient;
    private readonly string _endpoint;
    private readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public AssinaturasApiServiceClient(HttpClient httpClient, AssinaturasApiSettings apiSettings)
    {
        _httpClient = httpClient;
        _endpoint = apiSettings.Endpoint;
    }

    public async Task<ContaDto?> ObterContaPorIdAsync(Guid id, CancellationToken cancellationToken = default)
        => await _httpClient.GetFromJsonAsync<ContaDto>($"{_endpoint}/{id}", cancellationToken);

    public async Task<IList<ContaDto>> ObterContasAsync(CancellationToken cancellationToken = default)
    {
        var contas = await _httpClient.GetFromJsonAsync<IEnumerable<ContaDto>>(_endpoint, cancellationToken);

        return contas?.ToList() ?? new List<ContaDto>();
    }

    public async Task<bool> AtualizarContaAsync(ContaDto conta, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PutAsJsonAsync(_endpoint, conta, options: _jsonSerializerOptions, cancellationToken);

        return response.IsSuccessStatusCode;
    }

    public async Task<bool> RegistrarContaAsync(ContaDto conta, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsJsonAsync(_endpoint, conta, options: _jsonSerializerOptions, cancellationToken);

        return response.IsSuccessStatusCode;
    }

    public async Task<bool> RemoverContaAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.DeleteAsync($"{_endpoint}/{id}", cancellationToken);

        return response.IsSuccessStatusCode;
    }
}
