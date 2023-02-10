using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestesBeneficios.Infra.Data.Migrations
{
    public partial class Contratacoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contratacoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "Varchar(100)", nullable: false),
                    Email = table.Column<string>(type: "Varchar(100)", nullable: false),
                    Cpf = table.Column<string>(type: "Varchar(14)", nullable: false),
                    DataNacimento = table.Column<string>(type: "Varchar(100)", nullable: false),
                    Genero = table.Column<int>(type: "int", nullable: true),
                    EstadoCivil = table.Column<string>(type: "Varchar(100)", nullable: false),
                    NomeDaMae = table.Column<string>(type: "Varchar(100)", nullable: false),
                    Rg = table.Column<string>(type: "Varchar(100)", nullable: false),
                    OrgaoEmissor = table.Column<string>(type: "Varchar(100)", nullable: false),
                    DataExpedicaoRG = table.Column<string>(type: "Varchar(100)", nullable: false),
                    CartaoSUS = table.Column<string>(type: "Varchar(100)", nullable: false),
                    Cep = table.Column<string>(type: "Varchar(100)", nullable: false),
                    Logradouro = table.Column<string>(type: "Varchar(100)", nullable: false),
                    Numero = table.Column<string>(type: "Varchar(100)", nullable: false),
                    Complemento = table.Column<string>(type: "Varchar(100)", nullable: false),
                    Bairro = table.Column<string>(type: "Varchar(100)", nullable: false),
                    Cidade = table.Column<string>(type: "Varchar(100)", nullable: false),
                    Uf = table.Column<string>(type: "Varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contratacoes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contratacoes");
        }
    }
}
