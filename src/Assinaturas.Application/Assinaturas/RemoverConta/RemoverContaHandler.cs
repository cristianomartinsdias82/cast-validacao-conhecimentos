using Assinaturas.Domain.Assinaturas;
using MediatR;

namespace Assinaturas.Application.Assinaturas.RemoverConta;

public sealed class RemoverContaHandler : IRequestHandler<RemoverContaRequest, RemoverContaResponse>
{
    private readonly IContaRepository _contaRepository;

    public RemoverContaHandler(IContaRepository contaRepository)
    {
        _contaRepository = contaRepository;
    }

    public async Task<RemoverContaResponse> Handle(RemoverContaRequest request, CancellationToken cancellationToken)
    {
        //TODO: Implement it

        return new();
    }
}
