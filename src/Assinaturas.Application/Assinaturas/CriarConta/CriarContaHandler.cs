using Assinaturas.Domain.Assinaturas;
using MediatR;

namespace Assinaturas.Application.Assinaturas.CriarConta;

public sealed class CriarContaHandler : IRequestHandler<CriarContaRequest, CriarContaResponse>
{
    private readonly IContaRepository _contaRepository;

    public CriarContaHandler(IContaRepository contaRepository)
    {
        _contaRepository = contaRepository;
    }

    public async Task<CriarContaResponse> Handle(CriarContaRequest request, CancellationToken cancellationToken)
    {
        //TODO: Implement it

        return new();
    }
}
