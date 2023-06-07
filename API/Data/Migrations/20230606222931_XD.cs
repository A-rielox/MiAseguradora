using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class XD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Poliza_Usuarios_UsuarioId",
                table: "Poliza");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Poliza",
                table: "Poliza");

            migrationBuilder.RenameTable(
                name: "Poliza",
                newName: "Polizas");

            migrationBuilder.RenameIndex(
                name: "IX_Poliza_UsuarioId",
                table: "Polizas",
                newName: "IX_Polizas_UsuarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Polizas",
                table: "Polizas",
                column: "PolizaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Polizas_Usuarios_UsuarioId",
                table: "Polizas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Polizas_Usuarios_UsuarioId",
                table: "Polizas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Polizas",
                table: "Polizas");

            migrationBuilder.RenameTable(
                name: "Polizas",
                newName: "Poliza");

            migrationBuilder.RenameIndex(
                name: "IX_Polizas_UsuarioId",
                table: "Poliza",
                newName: "IX_Poliza_UsuarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Poliza",
                table: "Poliza",
                column: "PolizaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Poliza_Usuarios_UsuarioId",
                table: "Poliza",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
