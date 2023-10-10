using FluentValidation;
using static Assinaturas.Domain.SchemaMetadata.EntitiesSchemaMetadata;

namespace Assinaturas.Application.Assinaturas.CriarConta;

public sealed class CriarContaRequestValidator : AbstractValidator<CriarContaRequest>
{
    public CriarContaRequestValidator()
    {
        RuleFor(ct => ct.Nome)
            .NotEmpty()
            .WithErrorCode(((int)CriarContaErrorCodes.NomeNaoInformado).ToString());

        When(ct => !string.IsNullOrWhiteSpace(ct.Nome), () =>
        {
            RuleFor(ct => ct.Nome)
            .MaximumLength(ContasMetadata.NomeColumnLength)
            .WithErrorCode(((int)CriarContaErrorCodes.NomeComprimentoMaximo).ToString());
        });

        RuleFor(ct => ct.Descricao)
            .NotEmpty()
            .WithErrorCode(((int)CriarContaErrorCodes.DescricaoNaoInformado).ToString());

        When(ct => !string.IsNullOrWhiteSpace(ct.Descricao), () =>
        {
            RuleFor(ct => ct.Descricao)
            .MaximumLength(ContasMetadata.DescricaoColumnLength)
            .WithErrorCode(((int)CriarContaErrorCodes.DescricaoComprimentoMaximo).ToString());
        });
    }
}
