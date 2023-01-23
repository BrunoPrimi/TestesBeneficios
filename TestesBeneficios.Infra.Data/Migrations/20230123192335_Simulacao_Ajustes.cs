using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestesBeneficios.Infra.Data.Migrations
{
    public partial class Simulacao_Ajustes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Simulacoes_EntidadeDeClasses_EntidadeDeClasseId",
                table: "Simulacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Simulacoes_Profissoes_ProfissaoId",
                table: "Simulacoes");

            migrationBuilder.DropIndex(
                name: "IX_Simulacoes_EntidadeDeClasseId",
                table: "Simulacoes");

            migrationBuilder.DropIndex(
                name: "IX_Simulacoes_ProfissaoId",
                table: "Simulacoes");

            migrationBuilder.DropColumn(
                name: "EntidadeDeClasseId",
                table: "Simulacoes");

            migrationBuilder.DropColumn(
                name: "ProfissaoId",
                table: "Simulacoes");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdProfissao",
                table: "Simulacoes",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdEntidadeDeClasse",
                table: "Simulacoes",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Simulacoes",
                type: "Varchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Simulacoes",
                type: "Varchar(14)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "AbrangenciaProduto",
                table: "Simulacoes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Simulacoes_IdEntidadeDeClasse",
                table: "Simulacoes",
                column: "IdEntidadeDeClasse");

            migrationBuilder.CreateIndex(
                name: "IX_Simulacoes_IdProfissao",
                table: "Simulacoes",
                column: "IdProfissao");

            migrationBuilder.AddForeignKey(
                name: "FK_Simulacoes_EntidadeDeClasses_IdEntidadeDeClasse",
                table: "Simulacoes",
                column: "IdEntidadeDeClasse",
                principalTable: "EntidadeDeClasses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Simulacoes_Profissoes_IdProfissao",
                table: "Simulacoes",
                column: "IdProfissao",
                principalTable: "Profissoes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Simulacoes_EntidadeDeClasses_IdEntidadeDeClasse",
                table: "Simulacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Simulacoes_Profissoes_IdProfissao",
                table: "Simulacoes");

            migrationBuilder.DropIndex(
                name: "IX_Simulacoes_IdEntidadeDeClasse",
                table: "Simulacoes");

            migrationBuilder.DropIndex(
                name: "IX_Simulacoes_IdProfissao",
                table: "Simulacoes");

            migrationBuilder.DropColumn(
                name: "AbrangenciaProduto",
                table: "Simulacoes");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdProfissao",
                table: "Simulacoes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "IdEntidadeDeClasse",
                table: "Simulacoes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Simulacoes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Simulacoes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(14)");

            migrationBuilder.AddColumn<Guid>(
                name: "EntidadeDeClasseId",
                table: "Simulacoes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProfissaoId",
                table: "Simulacoes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Simulacoes_EntidadeDeClasseId",
                table: "Simulacoes",
                column: "EntidadeDeClasseId");

            migrationBuilder.CreateIndex(
                name: "IX_Simulacoes_ProfissaoId",
                table: "Simulacoes",
                column: "ProfissaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Simulacoes_EntidadeDeClasses_EntidadeDeClasseId",
                table: "Simulacoes",
                column: "EntidadeDeClasseId",
                principalTable: "EntidadeDeClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Simulacoes_Profissoes_ProfissaoId",
                table: "Simulacoes",
                column: "ProfissaoId",
                principalTable: "Profissoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
