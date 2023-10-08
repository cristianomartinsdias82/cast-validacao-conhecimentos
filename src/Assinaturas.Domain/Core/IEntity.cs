namespace Assinaturas.Domain.Core;

public interface IEntity
{
    public Guid Id { get; }
    public byte[] Revision { get; }
}
