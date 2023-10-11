using FluentValidation;

namespace Assinaturas.Application.Assinaturas.RemoverConta;

public sealed class RemoverContaRequestValidator : AbstractValidator<RemoverContaRequest>
{
    public RemoverContaRequestValidator()
    {
        RuleFor(ct => ct.Id)
            .NotEmpty()
            .WithErrorCode(((int)RemoverContaErrorCodes.IdNaoInformado).ToString());
    }
}
