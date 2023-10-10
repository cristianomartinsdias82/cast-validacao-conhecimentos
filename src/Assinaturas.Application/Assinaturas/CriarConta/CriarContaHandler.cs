using Assinaturas.Application.Assinaturas.Shared;
using Assinaturas.Domain.Assinaturas;
using Assinaturas.SharedKernel.Results;
using MediatR;

namespace Assinaturas.Application.Assinaturas.CriarConta;

internal sealed class CriarContaHandler : IRequestHandler<CriarContaRequest, Result<CriarContaResponse, Failure>>
{
    private readonly IContaRepository _contaRepository;

    public CriarContaHandler(IContaRepository contaRepository)
    {
        _contaRepository = contaRepository;
    }

    public async Task<Result<CriarContaResponse, Failure>> Handle(CriarContaRequest request, CancellationToken cancellationToken)
    {
        var criacaoNovaContaResult = await Conta.Criar(
                                            request.Nome,
                                            request.Descricao,
                                            _contaRepository,
                                            cancellationToken);

        if (criacaoNovaContaResult.IsSuccessful)
            return new CriarContaResponse(criacaoNovaContaResult.Value.MapToDto());

        return criacaoNovaContaResult.Error;
    }
}
