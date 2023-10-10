namespace Assinaturas.Domain.SchemaMetadata;

public static class EntitiesSchemaMetadata
{
    public static class ContasMetadata
    {
        public const string NomeColumnIndexName = "IX_Contas_Nome";
        public const string IdColumnPkName = "PK_Contas_Id";
        
        public const string NomeColumnDataType = "varchar";
        public const int NomeColumnLength = 20;
        public const bool NomeColumnIsRequired = true;
        public const bool NomeColumnIsUnique = true;

        public const string DescricaoColumnDataType = "varchar";
        public const int DescricaoColumnLength = 100;
        public const bool DescricaoColumnIsRequired = true;
        public const bool DescricaoColumnIsUnique = false;
    }
}