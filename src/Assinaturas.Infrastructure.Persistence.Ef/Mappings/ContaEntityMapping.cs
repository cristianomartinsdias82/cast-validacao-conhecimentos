using Assinaturas.Domain.Assinaturas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Assinaturas.Domain.SchemaMetadata.EntitiesSchemaMetadata;

namespace Assinaturas.Infrastructure.Persistence.Ef.Mappings;

internal class ContaEntityMapping : IEntityTypeConfiguration<Conta>
{
    public void Configure(EntityTypeBuilder<Conta> builder)
    {
        builder.ToTable(ContasMetadata.TableName);

        builder.HasKey(cn => cn.Id)
               .HasName(ContasMetadata.IdColumnPkName);

        builder.Property(cn => cn.Id)
                .ValueGeneratedNever();

        builder.Property(cn => cn.Nome)
               .IsRequired(ContasMetadata.NomeColumnIsRequired)
               .HasColumnType(ContasMetadata.NomeColumnDataType)
               .HasMaxLength(ContasMetadata.NomeColumnLength);

        builder.Property(cn => cn.Descricao)
               .IsRequired(ContasMetadata.DescricaoColumnIsRequired)
               .HasColumnType(ContasMetadata.DescricaoColumnDataType)
               .HasMaxLength(ContasMetadata.DescricaoColumnLength);
    }
}
