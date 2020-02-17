using Microsoft.EntityFrameworkCore.Migrations;

namespace Escuela2019.Migrations
{
    public partial class InitialCreate4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alertas_Usuarios_UsuarioIdentifier",
                table: "Alertas");

            migrationBuilder.DropForeignKey(
                name: "FK_Ubications_Alertas_AlertId",
                table: "Ubications");

            migrationBuilder.AddForeignKey(
                name: "FK_Alertas_Usuarios_UsuarioIdentifier",
                table: "Alertas",
                column: "UsuarioIdentifier",
                principalTable: "Usuarios",
                principalColumn: "Identifier",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ubications_Alertas_AlertId",
                table: "Ubications",
                column: "AlertId",
                principalTable: "Alertas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alertas_Usuarios_UsuarioIdentifier",
                table: "Alertas");

            migrationBuilder.DropForeignKey(
                name: "FK_Ubications_Alertas_AlertId",
                table: "Ubications");

            migrationBuilder.AddForeignKey(
                name: "FK_Alertas_Usuarios_UsuarioIdentifier",
                table: "Alertas",
                column: "UsuarioIdentifier",
                principalTable: "Usuarios",
                principalColumn: "Identifier",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ubications_Alertas_AlertId",
                table: "Ubications",
                column: "AlertId",
                principalTable: "Alertas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
