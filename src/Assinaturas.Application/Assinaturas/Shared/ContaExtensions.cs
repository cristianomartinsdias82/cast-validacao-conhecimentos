using Assinaturas.Domain.Assinaturas;

namespace Assinaturas.Application.Assinaturas.Shared;

internal static class ContaExtensions
{
    public static ContaDto MapToDto(this IConta conta)
        => new(conta.Id, conta.Nome, conta.Descricao);

    public static IEnumerable<ContaDto> BatchMapToDto(this IEnumerable<IConta> contas)
        => contas.Select(MapToDto).ToList();
}