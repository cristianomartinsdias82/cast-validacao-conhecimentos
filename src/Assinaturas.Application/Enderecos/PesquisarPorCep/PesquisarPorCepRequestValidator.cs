using FluentValidation;
using static Assinaturas.Application.Enderecos.PesquisarPorCep.PesquisarPorCepErrorCodes;

namespace Assinaturas.Application.Enderecos.PesquisarPorCep;

public sealed class PesquisarPorCepRequestValidator : AbstractValidator<PesquisarPorCepRequest>
{
    public PesquisarPorCepRequestValidator()
    {
        RuleFor(pesq => pesq.Cep)
            .NotEmpty()
            .WithErrorCode(((int)CepNaoInformado).ToString());

        When(pesq => !string.IsNullOrWhiteSpace(pesq.Cep), () => {

            RuleFor(it => it.Cep)
                .Matches(@"\d{8}")
                .WithErrorCode(((int)CepInvalido).ToString());

        });
    }
}
