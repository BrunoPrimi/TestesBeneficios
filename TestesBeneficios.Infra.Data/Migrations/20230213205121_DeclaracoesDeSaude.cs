using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestesBeneficios.Infra.Data.Migrations
{
    public partial class DeclaracoesDeSaude : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeclaracaoDeSaudes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Resposta = table.Column<int>(type: "int", nullable: false),
                    Detalhes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataDoEvento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeclaracaoDeSaudes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeclaracaoDeSaudes");
        }
    }
}
