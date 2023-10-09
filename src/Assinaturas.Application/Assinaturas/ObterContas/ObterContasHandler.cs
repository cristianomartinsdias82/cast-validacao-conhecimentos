using Assinaturas.Application.Assinaturas.Shared;
using Assinaturas.Domain.Assinaturas;
using MediatR;

namespace Assinaturas.Application.Assinaturas.ObterContas;

public sealed class ObterContasHandler : IRequestHandler<ObterContasRequest, ObterContasResponse>
{
    private readonly IContaRepository _contaRepository;

    public ObterContasHandler(IContaRepository contaRepository)
    {
        _contaRepository = contaRepository;
    }

    public async Task<ObterContasResponse> Handle(ObterContasRequest request, CancellationToken cancellationToken)
    {
        //TODO: Implement it

        return new(default!);
    }
}
