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
        var contas = await _contaRepository.FetchAsync(cancellationToken);

        return new(contas.Select(ct => ct.MapToDto()).ToList());
    }
}
