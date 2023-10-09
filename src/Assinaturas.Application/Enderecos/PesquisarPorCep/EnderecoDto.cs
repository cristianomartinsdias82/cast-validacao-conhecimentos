namespace Assinaturas.Application.Enderecos.PesquisarPorCep;

public sealed record EnderecoDto
(
    string Logradouro,
    string Bairro,
    string Cidade,
    string Uf
);