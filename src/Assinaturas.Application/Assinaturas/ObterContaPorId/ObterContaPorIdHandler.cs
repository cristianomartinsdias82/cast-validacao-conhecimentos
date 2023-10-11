using Assinaturas.Application.Assinaturas.Shared;
using Assinaturas.Domain.Assinaturas;
using MediatR;

namespace Assinaturas.Application.Assinaturas.ObterContaPorId;

internal sealed class ObterContaPorIdHandler : IRequestHandler<ObterContaPorIdRequest, ObterContaPorIdResponse>
{
    private readonly IContaRepository _contaRepository;

    public ObterContaPorIdHandler(IContaRepository contaRepository)
    {
        _contaRepository = contaRepository;
    }

    public async Task<ObterContaPorIdResponse> Handle(ObterContaPorIdRequest request, CancellationToken cancellationToken)
    {
        var conta = await _contaRepository.GetByIdAsync(request.Id, cancellationToken);

        return new(conta?.MapToDto());
    }
}
