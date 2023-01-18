using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestesBeneficios.Infra.Data.Migrations
{
    public partial class DistribuicaoVida : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DistribuicaoVidas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AlcanceInicial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlcanceFinal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdSimulacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SimulacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistribuicaoVidas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DistribuicaoVidas_Simulacoes_SimulacaoId",
                        column: x => x.SimulacaoId,
                        principalTable: "Simulacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DistribuicaoVidas_SimulacaoId",
                table: "DistribuicaoVidas",
                column: "SimulacaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DistribuicaoVidas");
        }
    }
}
