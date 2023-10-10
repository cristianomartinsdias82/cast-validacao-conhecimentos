using Assinaturas.SharedKernel.Results;

namespace Assinaturas.Application.Enderecos.PesquisarPorCep;

public interface IPesquisaEnderecoService
{
    Task<Result<EnderecoDto, int>> PesquisarPorCepAsync(string cep, CancellationToken cancellationToken = default);
}