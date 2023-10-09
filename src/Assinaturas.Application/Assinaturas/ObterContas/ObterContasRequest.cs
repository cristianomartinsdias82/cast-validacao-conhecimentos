using MediatR;

namespace Assinaturas.Application.Assinaturas.ObterContas;

public record struct ObterContasRequest(string Nome, string Descricao) : IRequest<ObterContasResponse>;
