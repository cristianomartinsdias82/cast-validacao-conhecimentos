using Assinaturas.Application.Enderecos.PesquisarPorCep;

namespace Assinaturas.Infrastructure.Integrations.ViaCep
{
    public sealed class PesquisaEnderecoService : IPesquisaEnderecoService
    {
        public async Task<EnderecoDto?> PesquisarPorCepAsync(string cep, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;

            return default;
        }
    }
}