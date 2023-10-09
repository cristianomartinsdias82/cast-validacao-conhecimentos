using Assinaturas.Domain.Assinaturas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Assinaturas.Domain.SchemaMetadata.EntitiesSchemaMetadata;

namespace Assinaturas.Infrastructure.Persistence.Ef.Mappings;

internal class ContaEntityMapping : IEntityTypeConfiguration<Conta>
{
    public void Configure(EntityTypeBuilder<Conta> builder)
    {
        builder.HasKey(cn => cn.Id)
               .HasName(Contas.IdColumnPkName);

        builder.Property(cn => cn.Id)
                .ValueGeneratedNever();

        builder.Property(cn => cn.Revision)
                .IsRowVersion()
                .ValueGeneratedOnAddOrUpdate();

        builder.Property(cn => cn.Nome)
               .IsRequired(Contas.NomeColumnIsRequired)
               .HasColumnType(Contas.NomeColumnDataType)
               .HasMaxLength(Contas.NomeColumnLength);

        builder.Property(cn => cn.Descricao)
               .IsRequired(Contas.DescricaoColumnIsRequired)
               .HasColumnType(Contas.DescricaoColumnDataType)
               .HasMaxLength(Contas.DescricaoColumnLength);
    }
}
