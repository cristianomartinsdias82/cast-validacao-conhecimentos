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
            RuleFor(pesq => pesq.Cep)
                .Must(cep => cep.Length.Equals(8) && int.TryParse(cep, out _))
                .WithErrorCode(((int)CepInvalido).ToString());

        });
    }
}