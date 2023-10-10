using Assinaturas.SharedKernel.Results;
using MediatR;

namespace Assinaturas.Application.Enderecos.PesquisarPorCep;

public sealed class PesquisarPorCepHandler : IRequestHandler<PesquisarPorCepRequest, Result<PesquisarPorCepResponse, int>>
{
    private readonly IPesquisaEnderecoService _pesquisaEnderecoService;

    public PesquisarPorCepHandler(IPesquisaEnderecoService pesquisaEnderecoService)
    {
        _pesquisaEnderecoService = pesquisaEnderecoService;
    }

    public async Task<Result<PesquisarPorCepResponse, int>> Handle(PesquisarPorCepRequest request, CancellationToken cancellationToken)
    {
        var result = await _pesquisaEnderecoService.PesquisarPorCepAsync(request.Cep, cancellationToken);

        if (result.IsSuccessful)
            return new PesquisarPorCepResponse(result.Value);

        return result.Error;
    }
}
