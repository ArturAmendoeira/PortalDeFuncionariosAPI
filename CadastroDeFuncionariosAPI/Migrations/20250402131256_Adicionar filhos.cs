using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroDeFuncionariosAPI.Migrations
{
    /// <inheritdoc />
    public partial class Adicionarfilhos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Filhos",
                table: "Funcionarios",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Filhos",
                table: "Funcionarios");
        }
    }
}
