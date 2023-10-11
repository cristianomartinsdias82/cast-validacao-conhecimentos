using FluentValidation;

namespace Assinaturas.Application.Assinaturas.ObterContaPorId;

public sealed class ObterContaPorIdRequestValidator : AbstractValidator<ObterContaPorIdRequest>
{
    public ObterContaPorIdRequestValidator()
    {
        RuleFor(ct => ct.Id)
            .NotEmpty()
            .WithErrorCode(((int)ObterContaPorIdErrorCodes.IdNaoInformado).ToString());
    }
}
