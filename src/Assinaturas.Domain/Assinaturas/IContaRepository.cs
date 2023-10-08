namespace Assinaturas.Domain.Assinaturas;

public interface IContaRepository
{
    Task<IList<IConta>> FetchAsync(CancellationToken cancellationToken = default);
    Task<IConta?> GetByIdAsync(CancellationToken cancellationToken = default);
    Task<bool> AddAsync(IConta conta, CancellationToken cancellationToken = default);
    Task<bool> UpdateAsync(IConta conta, CancellationToken cancellationToken = default);
    Task<bool> RemoveAsync(Guid id, CancellationToken cancellationToken = default);
}