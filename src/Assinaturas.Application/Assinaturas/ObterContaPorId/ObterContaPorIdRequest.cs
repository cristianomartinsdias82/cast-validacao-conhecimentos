using MediatR;

namespace Assinaturas.Application.Assinaturas.ObterContaPorId;

public record struct ObterContaPorIdRequest(Guid Id) : IRequest<ObterContaPorIdResponse>;
