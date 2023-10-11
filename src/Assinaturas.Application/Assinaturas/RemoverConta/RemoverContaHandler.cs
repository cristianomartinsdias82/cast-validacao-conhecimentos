using Assinaturas.Domain.Assinaturas;
using MediatR;

namespace Assinaturas.Application.Assinaturas.RemoverConta;

internal sealed class RemoverContaHandler : IRequestHandler<RemoverContaRequest, RemoverContaResponse>
{
    private readonly IContaRepository _contaRepository;

    public RemoverContaHandler(IContaRepository contaRepository)
    {
        _contaRepository = contaRepository;
    }

    public async Task<RemoverContaResponse> Handle(RemoverContaRequest request, CancellationToken cancellationToken)
    {
        await _contaRepository.RemoveAsync(request.Id, cancellationToken);

        return new();
    }
}