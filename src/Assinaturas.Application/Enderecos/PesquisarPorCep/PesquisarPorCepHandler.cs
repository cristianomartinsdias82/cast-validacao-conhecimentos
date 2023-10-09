using MediatR;

namespace Assinaturas.Application.Enderecos.PesquisarPorCep;

public sealed class PesquisarPorCepHandler : IRequestHandler<PesquisarPorCepRequest, PesquisarPorCepResponse>
{
    private readonly IPesquisaEnderecoService _pesquisaEnderecoService;

    public PesquisarPorCepHandler(IPesquisaEnderecoService pesquisaEnderecoService)
    {
        _pesquisaEnderecoService = pesquisaEnderecoService;
    }

    public async Task<PesquisarPorCepResponse> Handle(PesquisarPorCepRequest request, CancellationToken cancellationToken)
    {
        //TODO: Implement it

        return new(default!);
    }
}
