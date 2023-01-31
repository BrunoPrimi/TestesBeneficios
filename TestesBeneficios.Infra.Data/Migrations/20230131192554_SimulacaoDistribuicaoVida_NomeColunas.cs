using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestesBeneficios.Infra.Data.Migrations
{
    public partial class SimulacaoDistribuicaoVida_NomeColunas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "SimulacaoDistribuicaoVida",
                newName: "AlcanceInicial");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "SimulacaoDistribuicaoVida",
                newName: "AlcanceFinal");

            migrationBuilder.RenameColumn(
                name: "Cpf",
                table: "SimulacaoDistribuicaoVida",
                newName: "Quantidade");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantidade",
                table: "SimulacaoDistribuicaoVida",
                newName: "Cpf");

            migrationBuilder.RenameColumn(
                name: "AlcanceInicial",
                table: "SimulacaoDistribuicaoVida",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "AlcanceFinal",
                table: "SimulacaoDistribuicaoVida",
                newName: "Email");
        }
    }
}
