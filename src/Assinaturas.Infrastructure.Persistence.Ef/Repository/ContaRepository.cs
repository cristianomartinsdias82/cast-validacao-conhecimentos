using Assinaturas.Domain.Assinaturas;

namespace Assinaturas.Infrastructure.Persistence.Ef.Repository;

internal sealed class ContaRepository : IContaRepository
{
    private readonly AssinaturasDbContext _dbContext;

    public ContaRepository(AssinaturasDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> AddAsync(Conta conta, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<IList<IConta>> FetchAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<IConta?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> RemoveAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateAsync(Conta conta, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
