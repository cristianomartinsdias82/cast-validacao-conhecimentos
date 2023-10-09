using MediatR;

namespace Assinaturas.Application.Assinaturas.RemoverConta;

public record struct RemoverContaRequest(Guid Id) : IRequest<RemoverContaResponse>;
