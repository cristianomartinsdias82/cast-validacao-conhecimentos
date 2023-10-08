namespace Assinaturas.Domain.Core;

public interface IAuditableEntity : IEntity
{
    DateTime CreatedOn { get; }
    Guid CreatedUserId { get; }

    DateTime? UpdatedOn { get; set; }
    Guid? UpdatedUserId { get; set; }
}
