using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assinaturas.Infrastructure.Persistence.Ef.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "varchar", maxLength: 20, nullable: false),
                    Descricao = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    Revision = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedUserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UpdatedUserId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contas_Id", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contas_Nome",
                table: "Conta",
                column: "Nome",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conta");
        }
    }
}
