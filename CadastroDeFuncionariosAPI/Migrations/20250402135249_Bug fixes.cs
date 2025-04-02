using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroDeFuncionariosAPI.Migrations
{
    /// <inheritdoc />
    public partial class Bugfixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filhos_Funcionarios_CPF",
                table: "Filhos");

            migrationBuilder.DropColumn(
                name: "Filhos",
                table: "Funcionarios");

            migrationBuilder.AddColumn<string>(
                name: "FuncionarioResponsavelCPF",
                table: "Filhos",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Filhos_FuncionarioResponsavelCPF",
                table: "Filhos",
                column: "FuncionarioResponsavelCPF");

            migrationBuilder.AddForeignKey(
                name: "FK_Filhos_Funcionarios_FuncionarioResponsavelCPF",
                table: "Filhos",
                column: "FuncionarioResponsavelCPF",
                principalTable: "Funcionarios",
                principalColumn: "CPF",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filhos_Funcionarios_FuncionarioResponsavelCPF",
                table: "Filhos");

            migrationBuilder.DropIndex(
                name: "IX_Filhos_FuncionarioResponsavelCPF",
                table: "Filhos");

            migrationBuilder.DropColumn(
                name: "FuncionarioResponsavelCPF",
                table: "Filhos");

            migrationBuilder.AddColumn<int>(
                name: "Filhos",
                table: "Funcionarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Filhos_Funcionarios_CPF",
                table: "Filhos",
                column: "CPF",
                principalTable: "Funcionarios",
                principalColumn: "CPF",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
