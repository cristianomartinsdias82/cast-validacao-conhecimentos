using Assinaturas.Application.Assinaturas.CriarConta;
using FluentValidation;
using static Assinaturas.Domain.SchemaMetadata.EntitiesSchemaMetadata;

namespace Assinaturas.Application.Assinaturas.AtualizarConta;

public sealed class AtualizarContaRequestValidator : AbstractValidator<AtualizarContaRequest>
{
    public AtualizarContaRequestValidator()
    {
        RuleFor(ct => ct.Id)
            .NotEmpty()
            .WithErrorCode(((int)AtualizarContaErrorCodes.IdNaoInformado).ToString());

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
