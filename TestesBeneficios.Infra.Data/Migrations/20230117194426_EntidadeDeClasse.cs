using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestesBeneficios.Infra.Data.Migrations
{
    public partial class EntidadeDeClasse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EntidadeDeClasses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CNPJ = table.Column<string>(type: "Varchar(100)", nullable: false),
                    RazaoSocial = table.Column<string>(type: "Varchar(100)", nullable: false),
                    NomeFantasia = table.Column<string>(type: "Varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntidadeDeClasses", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntidadeDeClasses");
        }
    }
}
