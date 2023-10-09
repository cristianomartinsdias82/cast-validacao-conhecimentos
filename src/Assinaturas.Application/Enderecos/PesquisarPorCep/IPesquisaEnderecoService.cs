namespace Assinaturas.Application.Enderecos.PesquisarPorCep;

public interface IPesquisaEnderecoService
{
    Task<EnderecoDto?> PesquisarPorCepAsync(string cep, CancellationToken cancellationToken = default);
}