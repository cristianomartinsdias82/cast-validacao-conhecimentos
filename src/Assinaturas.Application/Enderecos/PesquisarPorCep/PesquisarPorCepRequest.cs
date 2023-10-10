using Assinaturas.Application.Core.Results;
using MediatR;

namespace Assinaturas.Application.Enderecos.PesquisarPorCep;

public record struct PesquisarPorCepRequest(string Cep) : IRequest<Result<PesquisarPorCepResponse, int>>;
