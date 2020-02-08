using Microsoft.EntityFrameworkCore.Migrations;

namespace Escuela2019.Migrations
{
    public partial class InitialCreate4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNUmber",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Direction",
                table: "Alertas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Alertas",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Alertas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alertas_UsuarioId",
                table: "Alertas",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alertas_Usuarios_UsuarioId",
                table: "Alertas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alertas_Usuarios_UsuarioId",
                table: "Alertas");

            migrationBuilder.DropIndex(
                name: "IX_Alertas_UsuarioId",
                table: "Alertas");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "PhoneNUmber",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Direction",
                table: "Alertas");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Alertas");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Alertas");
        }
    }
}
