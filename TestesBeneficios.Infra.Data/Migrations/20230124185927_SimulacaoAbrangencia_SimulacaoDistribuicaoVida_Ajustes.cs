using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestesBeneficios.Infra.Data.Migrations
{
    public partial class SimulacaoAbrangencia_SimulacaoDistribuicaoVida_Ajustes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abrangencias_Simulacoes_SimulacaoId",
                table: "Abrangencias");

            migrationBuilder.DropForeignKey(
                name: "FK_DistribuicaoVidas_Simulacoes_SimulacaoId",
                table: "DistribuicaoVidas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DistribuicaoVidas",
                table: "DistribuicaoVidas");

            migrationBuilder.DropIndex(
                name: "IX_DistribuicaoVidas_SimulacaoId",
                table: "DistribuicaoVidas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Abrangencias",
                table: "Abrangencias");

            migrationBuilder.DropIndex(
                name: "IX_Abrangencias_SimulacaoId",
                table: "Abrangencias");

            migrationBuilder.DropColumn(
                name: "SimulacaoId",
                table: "DistribuicaoVidas");

            migrationBuilder.DropColumn(
                name: "SimulacaoId",
                table: "Abrangencias");

            migrationBuilder.RenameTable(
                name: "DistribuicaoVidas",
                newName: "SimulacaoDistribuicaoVida");

            migrationBuilder.RenameTable(
                name: "Abrangencias",
                newName: "SimulacaoAbrangencia");

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

            migrationBuilder.RenameColumn(
                name: "Uf",
                table: "SimulacaoAbrangencia",
                newName: "UF");

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "SimulacaoDistribuicaoVida",
                type: "Varchar(14)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "SimulacaoDistribuicaoVida",
                type: "Varchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "SimulacaoDistribuicaoVida",
                type: "Varchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SimulacaoDistribuicaoVida",
                table: "SimulacaoDistribuicaoVida",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SimulacaoAbrangencia",
                table: "SimulacaoAbrangencia",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SimulacaoDistribuicaoVida_IdSimulacao",
                table: "SimulacaoDistribuicaoVida",
                column: "IdSimulacao");

            migrationBuilder.CreateIndex(
                name: "IX_SimulacaoAbrangencia_IdSimulacao",
                table: "SimulacaoAbrangencia",
                column: "IdSimulacao");

            migrationBuilder.AddForeignKey(
                name: "FK_SimulacaoAbrangencia_Simulacoes_IdSimulacao",
                table: "SimulacaoAbrangencia",
                column: "IdSimulacao",
                principalTable: "Simulacoes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SimulacaoDistribuicaoVida_Simulacoes_IdSimulacao",
                table: "SimulacaoDistribuicaoVida",
                column: "IdSimulacao",
                principalTable: "Simulacoes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SimulacaoAbrangencia_Simulacoes_IdSimulacao",
                table: "SimulacaoAbrangencia");

            migrationBuilder.DropForeignKey(
                name: "FK_SimulacaoDistribuicaoVida_Simulacoes_IdSimulacao",
                table: "SimulacaoDistribuicaoVida");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SimulacaoDistribuicaoVida",
                table: "SimulacaoDistribuicaoVida");

            migrationBuilder.DropIndex(
                name: "IX_SimulacaoDistribuicaoVida_IdSimulacao",
                table: "SimulacaoDistribuicaoVida");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SimulacaoAbrangencia",
                table: "SimulacaoAbrangencia");

            migrationBuilder.DropIndex(
                name: "IX_SimulacaoAbrangencia_IdSimulacao",
                table: "SimulacaoAbrangencia");

            migrationBuilder.RenameTable(
                name: "SimulacaoDistribuicaoVida",
                newName: "DistribuicaoVidas");

            migrationBuilder.RenameTable(
                name: "SimulacaoAbrangencia",
                newName: "Abrangencias");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "DistribuicaoVidas",
                newName: "AlcanceInicial");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "DistribuicaoVidas",
                newName: "AlcanceFinal");

            migrationBuilder.RenameColumn(
                name: "Cpf",
                table: "DistribuicaoVidas",
                newName: "Quantidade");

            migrationBuilder.RenameColumn(
                name: "UF",
                table: "Abrangencias",
                newName: "Uf");

            migrationBuilder.AlterColumn<string>(
                name: "AlcanceInicial",
                table: "DistribuicaoVidas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "AlcanceFinal",
                table: "DistribuicaoVidas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "Quantidade",
                table: "DistribuicaoVidas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(14)");

            migrationBuilder.AddColumn<Guid>(
                name: "SimulacaoId",
                table: "DistribuicaoVidas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SimulacaoId",
                table: "Abrangencias",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_DistribuicaoVidas",
                table: "DistribuicaoVidas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Abrangencias",
                table: "Abrangencias",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DistribuicaoVidas_SimulacaoId",
                table: "DistribuicaoVidas",
                column: "SimulacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Abrangencias_SimulacaoId",
                table: "Abrangencias",
                column: "SimulacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Abrangencias_Simulacoes_SimulacaoId",
                table: "Abrangencias",
                column: "SimulacaoId",
                principalTable: "Simulacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DistribuicaoVidas_Simulacoes_SimulacaoId",
                table: "DistribuicaoVidas",
                column: "SimulacaoId",
                principalTable: "Simulacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
