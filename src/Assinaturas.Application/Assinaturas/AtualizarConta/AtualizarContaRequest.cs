﻿using Assinaturas.SharedKernel.Results;
using MediatR;

namespace Assinaturas.Application.Assinaturas.AtualizarConta;

public record struct AtualizarContaRequest(Guid Id, string Nome, string Descricao) : IRequest<Result<AtualizarContaResponse, Failure>>;
