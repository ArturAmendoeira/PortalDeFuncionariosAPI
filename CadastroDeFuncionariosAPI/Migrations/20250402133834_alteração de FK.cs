using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroDeFuncionariosAPI.Migrations
{
    /// <inheritdoc />
    public partial class alteraçãodeFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Filhos",
                columns: table => new
                {
                    CPF = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataDeNascimento = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filhos", x => x.CPF);
                    table.ForeignKey(
                        name: "FK_Filhos_Funcionarios_CPF",
                        column: x => x.CPF,
                        principalTable: "Funcionarios",
                        principalColumn: "CPF",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Filhos");
        }
    }
}
