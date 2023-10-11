using Assinaturas.Application.Assinaturas.Shared;
using Assinaturas.Domain.Assinaturas;
using Assinaturas.SharedKernel.Results;
using MediatR;

namespace Assinaturas.Application.Assinaturas.AtualizarConta;

internal sealed class AtualizarContaHandler : IRequestHandler<AtualizarContaRequest, Result<AtualizarContaResponse, Failure>>
{
    private readonly IContaRepository _contaRepository;

    public AtualizarContaHandler(IContaRepository contaRepository)
    {
        _contaRepository = contaRepository;
    }

    public async Task<Result<AtualizarContaResponse, Failure>> Handle(AtualizarContaRequest request, CancellationToken cancellationToken)
    {
        var conta = await _contaRepository.GetByIdAsync(request.Id, cancellationToken);
        if (conta is null)
            return Failure.InputValidationError((int)AtualizarContaErrorCodes.ContaNaoEncontrada, default!);

        var atualizacaoContaResult = await conta.Atualizar(
                                            request.Nome,
                                            request.Descricao,
                                            _contaRepository,
                                            cancellationToken);

        if (atualizacaoContaResult.IsSuccessful)
            return new AtualizarContaResponse(atualizacaoContaResult.Value.MapToDto());

        return atualizacaoContaResult.Error;
    }
}
