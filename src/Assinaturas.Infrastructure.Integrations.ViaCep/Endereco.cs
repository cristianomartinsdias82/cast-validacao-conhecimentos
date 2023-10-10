using Assinaturas.Application.Enderecos.PesquisarPorCep;
using System.Text.Json.Serialization;

namespace Assinaturas.Infrastructure.Integrations.ViaCep;

public sealed record Endereco
{
    [JsonPropertyName("cep")]
    public string? Cep { get; init; }

    [JsonPropertyName("logradouro")]
    public string? Logradouro { get; init; }

    [JsonPropertyName("complemento")]
    public string? Complemento { get; init; }

    [JsonPropertyName("bairro")]
    public string? Bairro { get; init; }

    [JsonPropertyName("localidade")]
    public string? Localidade { get; init; }

    [JsonPropertyName("uf")]
    public string? Uf { get; init; }

    [JsonPropertyName("ibge")]
    public string? Ibge { get; init; }

    [JsonPropertyName("gia")]
    public string? Gia { get; init; }

    [JsonPropertyName("ddd")]
    public string? Ddd { get; init; }

    [JsonPropertyName("siafi")]
    public string? Siafi { get; init; }

    [JsonPropertyName("erro")]
    public bool? Erro { get; set; }

    public EnderecoDto MapToDto()
        => new()
        {
            Cep = Cep,
            Logradouro = Logradouro,
            Complemento = Complemento,
            Bairro = Bairro,
            Cidade = Localidade,
            Uf = Uf,
            Ibge = Ibge,
            Gia = Gia,
            Ddd = Ddd
        };
}