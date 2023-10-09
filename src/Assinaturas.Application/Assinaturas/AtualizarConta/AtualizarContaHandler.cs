using Assinaturas.Domain.Assinaturas;
using MediatR;

namespace Assinaturas.Application.Assinaturas.AtualizarConta;

public sealed class AtualizarContaHandler : IRequestHandler<AtualizarContaRequest, AtualizarContaResponse>
{
    private readonly IContaRepository _contaRepository;

    public AtualizarContaHandler(IContaRepository contaRepository)
    {
        _contaRepository = contaRepository;
    }

    public async Task<AtualizarContaResponse> Handle(AtualizarContaRequest request, CancellationToken cancellationToken)
    {
        //TODO: Implement it

        return new();
    }
}
