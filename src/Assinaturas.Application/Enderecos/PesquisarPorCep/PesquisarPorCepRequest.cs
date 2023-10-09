using MediatR;

namespace Assinaturas.Application.Enderecos.PesquisarPorCep;

public record struct PesquisarPorCepRequest(string Cep) : IRequest<PesquisarPorCepResponse>;
