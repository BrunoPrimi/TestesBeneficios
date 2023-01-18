using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestesBeneficios.Infra.Data.Migrations
{
    public partial class SimulacaoAbrangencia_Criacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abrangencias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Uf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdSimulacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SimulacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abrangencias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Abrangencias_Simulacoes_SimulacaoId",
                        column: x => x.SimulacaoId,
                        principalTable: "Simulacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Abrangencias_SimulacaoId",
                table: "Abrangencias",
                column: "SimulacaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abrangencias");
        }
    }
}
