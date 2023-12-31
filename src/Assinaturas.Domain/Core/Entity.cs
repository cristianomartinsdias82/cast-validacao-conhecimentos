﻿namespace Assinaturas.Domain.Core;

public abstract class Entity : IAuditableEntity
{
    public Guid Id { get; protected set; }
    public DateTime CreatedOn { get; set; }
    public Guid CreatedUserId { get; set; }
    public DateTime? UpdatedOn { get; set; }
    public Guid? UpdatedUserId { get; set; }
}
