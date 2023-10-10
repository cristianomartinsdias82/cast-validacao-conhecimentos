using Assinaturas.Application.Core.Behaviours.Validation;
using Assinaturas.SharedKernel.Results;
using MediatR;

namespace Assinaturas.Application.Assinaturas.CriarConta;

public record struct CriarContaRequest(string Nome, string Descricao) : IRequest<Result<CriarContaResponse, Failure>>;
