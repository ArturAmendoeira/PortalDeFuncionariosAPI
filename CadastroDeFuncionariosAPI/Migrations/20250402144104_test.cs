using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroDeFuncionariosAPI.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filhos_Funcionarios_FuncionarioResponsavelCPF",
                table: "Filhos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Funcionarios",
                table: "Funcionarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Filhos",
                table: "Filhos");

            migrationBuilder.DropIndex(
                name: "IX_Filhos_FuncionarioResponsavelCPF",
                table: "Filhos");

            migrationBuilder.DropColumn(
                name: "FuncionarioResponsavelCPF",
                table: "Filhos");

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Funcionarios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Funcionarios",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Filhos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Filhos",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ResponsavelId",
                table: "Filhos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Funcionarios",
                table: "Funcionarios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Filhos",
                table: "Filhos",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Filhos_ResponsavelId",
                table: "Filhos",
                column: "ResponsavelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Filhos_Funcionarios_ResponsavelId",
                table: "Filhos",
                column: "ResponsavelId",
                principalTable: "Funcionarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filhos_Funcionarios_ResponsavelId",
                table: "Filhos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Funcionarios",
                table: "Funcionarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Filhos",
                table: "Filhos");

            migrationBuilder.DropIndex(
                name: "IX_Filhos_ResponsavelId",
                table: "Filhos");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Filhos");

            migrationBuilder.DropColumn(
                name: "ResponsavelId",
                table: "Filhos");

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Funcionarios",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Filhos",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "FuncionarioResponsavelCPF",
                table: "Filhos",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Funcionarios",
                table: "Funcionarios",
                column: "CPF");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Filhos",
                table: "Filhos",
                column: "CPF");

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
    }
}
