
namespace Assinaturas.Application.Enderecos.PesquisarPorCep;

public sealed record EnderecoDto
{
    public string? Cep { get; init; }
    public string? Logradouro { get; init; }
    public string? Complemento { get; init; }
    public string? Bairro { get; init; }
    public string? Cidade { get; init; }
    public string? Uf { get; init; }
    public string? Ibge { get; init; }
    public string? Gia { get; init; }
    public string? Ddd { get; init; }
    public bool Vazio => Logradouro is null;
}