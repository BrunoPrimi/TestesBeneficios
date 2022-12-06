using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestesBeneficios.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class FaixaEtaria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FaixaEtaria",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FaixaDe = table.Column<int>(type: "int", nullable: false),
                    FaixaAte = table.Column<int>(type: "int", nullable: false),
                    Preço = table.Column<float>(type: "real", nullable: false),
                    IdProduto = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaixaEtaria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FaixaEtaria_Produtos_IdProduto",
                        column: x => x.IdProduto,
                        principalTable: "Produtos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FaixaEtaria_IdProduto",
                table: "FaixaEtaria",
                column: "IdProduto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FaixaEtaria");
        }
    }
}
