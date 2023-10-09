using Assinaturas.Domain.Assinaturas;
using Assinaturas.Domain.Core;
using Microsoft.EntityFrameworkCore;
using static Assinaturas.Domain.SchemaMetadata.EntitiesSchemaMetadata;

namespace Assinaturas.Infrastructure.Persistence.Ef;

internal sealed class AssinaturasDbContext : DbContext
{
    public AssinaturasDbContext(DbContextOptions<AssinaturasDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssinaturasDbContext).Assembly);

        modelBuilder.Entity<Conta>()
                    .HasIndex(ld => ld.Nome, Contas.NomeColumnIndexName)
                    .IsUnique(Contas.NomeColumnIsUnique);

        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var currentUserId = Guid.NewGuid();//TODO: iamService.GetUserId();
        var now = DateTime.UtcNow;

        foreach (var entry in ChangeTracker
                                .Entries()
                                .Where(e => e.Entity is IAuditableEntity))
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    {
                        var auditableEntity = (IAuditableEntity)entry.Entity;
                        auditableEntity.CreatedOn = now;
                        auditableEntity.CreatedUserId = currentUserId;

                        break;
                    }
                case EntityState.Modified:
                    {
                        var auditableEntity = (IAuditableEntity)entry.Entity;
                        auditableEntity.UpdatedOn = now;
                        auditableEntity.UpdatedUserId = currentUserId;

                        break;
                    }
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }

    public override int SaveChanges()
        => SaveChangesAsync().GetAwaiter().GetResult();
}
