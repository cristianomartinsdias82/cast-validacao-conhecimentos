using FluentValidation;

namespace Assinaturas.Application.Enderecos.PesquisarPorCep;

public sealed class PesquisarPorCepRequestValidator : AbstractValidator<PesquisarPorCepRequest>
{
    public PesquisarPorCepRequestValidator()
    {
        RuleFor(pesq => pesq.Cep)
            .NotEmpty()
            .WithErrorCode("1001")
            .Matches(@"\d{8}")
            .WithErrorCode("1002");
    }
}
