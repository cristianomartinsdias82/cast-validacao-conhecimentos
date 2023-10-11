using Assinaturas.Domain.Assinaturas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Linq.Expressions;

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
        await _dbContext.Contas.AddAsync(conta, cancellationToken);
        var rowsAffected = await _dbContext.SaveChangesAsync(cancellationToken);

        return rowsAffected > 0;
    }

    public async Task<bool> CheckExistsAsync(Expression<Func<Conta, bool>> expression, CancellationToken cancellationToken = default)
    {
        var conta = await _dbContext
                            .Contas
                            .AsNoTracking()
                            .FirstOrDefaultAsync(expression,cancellationToken);

        return conta is not null;
    }

    public async Task<IList<Conta>> FetchAsync(CancellationToken cancellationToken = default)
        => await _dbContext
                    .Contas
                    .AsNoTracking()
                    .OrderByDescending(ct => ct.CreatedOn)
                    .ToListAsync(cancellationToken);

    public async Task<Conta?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
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
