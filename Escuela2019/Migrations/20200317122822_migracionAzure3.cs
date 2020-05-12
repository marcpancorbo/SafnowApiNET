using Microsoft.EntityFrameworkCore.Migrations;

namespace Escuela2019.Migrations
{
    public partial class migracionAzure3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Usuarios_PhoneNumber",
                table: "Usuarios");

            migrationBuilder.AlterColumn<string>(
                name: "VerificationCode",
                table: "Usuarios",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf-8",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Verificated",
                table: "Usuarios",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Usuarios",
                maxLength: 9,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(9) CHARACTER SET utf-8",
                oldMaxLength: 9,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Usuarios",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf-8",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Identifier",
                table: "Usuarios",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255) CHARACTER SET utf-8");

            migrationBuilder.AlterColumn<string>(
                name: "Latitude",
                table: "Ubications",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf-8",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Altitude",
                table: "Ubications",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf-8",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Ubications",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Codes",
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5) CHARACTER SET utf-8",
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Codes",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioIdentifier",
                table: "Alertas",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255) CHARACTER SET utf-8",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Alertas",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf-8",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Direction",
                table: "Alertas",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf-8",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Alertas",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_PhoneNumber",
                table: "Usuarios",
                column: "PhoneNumber",
                unique: true,
                filter: "[PhoneNumber] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Usuarios_PhoneNumber",
                table: "Usuarios");

            migrationBuilder.AlterColumn<string>(
                name: "VerificationCode",
                table: "Usuarios",
                type: "longtext CHARACTER SET utf-8",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "Verificated",
                table: "Usuarios",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Usuarios",
                type: "varchar(9) CHARACTER SET utf-8",
                maxLength: 9,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 9,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Usuarios",
                type: "longtext CHARACTER SET utf-8",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Identifier",
                table: "Usuarios",
                type: "varchar(255) CHARACTER SET utf-8",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Latitude",
                table: "Ubications",
                type: "longtext CHARACTER SET utf-8",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Altitude",
                table: "Ubications",
                type: "longtext CHARACTER SET utf-8",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Ubications",
                type: "int",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Codes",
                type: "varchar(5) CHARACTER SET utf-8",
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Codes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioIdentifier",
                table: "Alertas",
                type: "varchar(255) CHARACTER SET utf-8",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Alertas",
                type: "longtext CHARACTER SET utf-8",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Direction",
                table: "Alertas",
                type: "longtext CHARACTER SET utf-8",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Alertas",
                type: "int",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_PhoneNumber",
                table: "Usuarios",
                column: "PhoneNumber",
                unique: true);
        }
    }
}
