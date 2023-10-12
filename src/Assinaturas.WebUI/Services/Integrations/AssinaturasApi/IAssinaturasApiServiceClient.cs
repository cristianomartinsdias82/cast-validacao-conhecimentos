using Assinaturas.WebUI.Models.Assinaturas;

namespace Assinaturas.WebUI.Core.Integrations.AssinaturasApi;

public interface IAssinaturasApiServiceClient
{
    Task<IList<ContaDto>> ObterContasAsync(CancellationToken cancellationToken = default);
    Task<ContaDto?> ObterContaPorIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<bool> RegistrarContaAsync(ContaDto conta, CancellationToken cancellationToken = default);
    Task<bool> AtualizarContaAsync(ContaDto conta, CancellationToken cancellationToken = default);
    Task<bool> RemoverContaAsync(Guid id, CancellationToken cancellationToken = default);
}
