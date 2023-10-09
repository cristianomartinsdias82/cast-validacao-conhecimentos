using Assinaturas.Application.Assinaturas.Shared;
using Assinaturas.Domain.Assinaturas;
using MediatR;

namespace Assinaturas.Application.Assinaturas.ObterContaPorId;

public sealed class ObterContaPorIdHandler : IRequestHandler<ObterContaPorIdRequest, ObterContaPorIdResponse>
{
    private readonly IContaRepository _contaRepository;

    public ObterContaPorIdHandler(IContaRepository contaRepository)
    {
        _contaRepository = contaRepository;
    }

    public async Task<ObterContaPorIdResponse> Handle(ObterContaPorIdRequest request, CancellationToken cancellationToken)
    {
        //TODO: Implement it

        return new(default!);
    }
}
