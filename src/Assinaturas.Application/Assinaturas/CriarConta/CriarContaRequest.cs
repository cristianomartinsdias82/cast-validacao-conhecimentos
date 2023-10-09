using MediatR;

namespace Assinaturas.Application.Assinaturas.CriarConta;

public record struct CriarContaRequest(string Nome, string Descricao) : IRequest<CriarContaResponse>;
