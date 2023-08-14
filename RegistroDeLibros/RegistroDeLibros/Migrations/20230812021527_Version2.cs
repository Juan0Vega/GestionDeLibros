using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroDeLibros.Migrations
{
    /// <inheritdoc />
    public partial class Version2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libro_Autor_IdAutor",
                table: "Libro");

            migrationBuilder.DropIndex(
                name: "IX_Libro_IdAutor",
                table: "Libro");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Autor",
                table: "Autor");

            migrationBuilder.DropColumn(
                name: "IdAutor",
                table: "Libro");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Autor");

            migrationBuilder.AddColumn<string>(
                name: "NombreAutor",
                table: "Libro",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Autor",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Autor",
                table: "Autor",
                column: "Nombre");

            migrationBuilder.CreateIndex(
                name: "IX_Libro_NombreAutor",
                table: "Libro",
                column: "NombreAutor");

            migrationBuilder.AddForeignKey(
                name: "FK_Libro_Autor_NombreAutor",
                table: "Libro",
                column: "NombreAutor",
                principalTable: "Autor",
                principalColumn: "Nombre",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libro_Autor_NombreAutor",
                table: "Libro");

            migrationBuilder.DropIndex(
                name: "IX_Libro_NombreAutor",
                table: "Libro");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Autor",
                table: "Autor");

            migrationBuilder.DropColumn(
                name: "NombreAutor",
                table: "Libro");

            migrationBuilder.AddColumn<int>(
                name: "IdAutor",
                table: "Libro",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Autor",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Autor",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Autor",
                table: "Autor",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Libro_IdAutor",
                table: "Libro",
                column: "IdAutor");

            migrationBuilder.AddForeignKey(
                name: "FK_Libro_Autor_IdAutor",
                table: "Libro",
                column: "IdAutor",
                principalTable: "Autor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
