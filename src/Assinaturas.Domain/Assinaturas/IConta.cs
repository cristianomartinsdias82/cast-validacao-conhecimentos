using Assinaturas.Domain.Core;

namespace Assinaturas.Domain.Assinaturas;

public interface IConta : IEntity
{
    string Nome { get; }
    string Descricao { get; }
}
