using System.Linq.Expressions;

namespace Assinaturas.Domain.Assinaturas;

public interface IContaRepository
{
    Task<IList<Conta>> FetchAsync(CancellationToken cancellationToken = default);
    Task<Conta?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<bool> AddAsync(Conta conta, CancellationToken cancellationToken = default);
    Task<bool> UpdateAsync(Conta conta, CancellationToken cancellationToken = default);
    Task<bool> RemoveAsync(Guid id, CancellationToken cancellationToken = default);
    Task<bool> CheckExistsAsync(Expression<Func<Conta, bool>> expression, CancellationToken cancellationToken = default);
}