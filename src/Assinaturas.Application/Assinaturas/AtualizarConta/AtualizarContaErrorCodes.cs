namespace Assinaturas.Application.Assinaturas.AtualizarConta;

public enum AtualizarContaErrorCodes : int
{
    IdNaoInformado = 5001,
    NomeNaoInformado = 5002,
    NomeComprimentoMaximo = 5003,
    DescricaoNaoInformado = 5004,
    DescricaoComprimentoMaximo = 5005,
    ContaNaoEncontrada = 5006
}