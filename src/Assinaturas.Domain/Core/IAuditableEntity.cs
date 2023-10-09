namespace Assinaturas.Domain.Core;

public interface IAuditableEntity : IEntity
{
    DateTime CreatedOn { get; set; }
    Guid CreatedUserId { get; set; }

    DateTime? UpdatedOn { get; set; }
    Guid? UpdatedUserId { get; set; }
}
