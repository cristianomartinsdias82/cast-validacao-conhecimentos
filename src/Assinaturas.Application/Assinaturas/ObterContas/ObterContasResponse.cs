using Assinaturas.Application.Assinaturas.Shared;

namespace Assinaturas.Application.Assinaturas.ObterContas;

public record struct ObterContasResponse(IList<ContaDto> Contas);