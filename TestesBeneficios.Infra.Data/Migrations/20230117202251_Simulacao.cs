using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestesBeneficios.Infra.Data.Migrations
{
    public partial class Simulacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Simulacoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "Varchar(100)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdProfissao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfissaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdEntidadeDeClasse = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntidadeDeClasseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Simulacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Simulacoes_EntidadeDeClasses_EntidadeDeClasseId",
                        column: x => x.EntidadeDeClasseId,
                        principalTable: "EntidadeDeClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Simulacoes_Profissoes_ProfissaoId",
                        column: x => x.ProfissaoId,
                        principalTable: "Profissoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Simulacoes_EntidadeDeClasseId",
                table: "Simulacoes",
                column: "EntidadeDeClasseId");

            migrationBuilder.CreateIndex(
                name: "IX_Simulacoes_ProfissaoId",
                table: "Simulacoes",
                column: "ProfissaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Simulacoes");
        }
    }
}
