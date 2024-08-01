using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LivrariaMVC.Migrations
{
    /// <inheritdoc />
    public partial class NovasTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LivroGenero_Generos_GeneroId",
                table: "LivroGenero");

            migrationBuilder.DropForeignKey(
                name: "FK_LivroGenero_Livros_LivroId",
                table: "LivroGenero");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LivroGenero",
                table: "LivroGenero");

            migrationBuilder.RenameTable(
                name: "LivroGenero",
                newName: "LivroGeneros");

            migrationBuilder.RenameIndex(
                name: "IX_LivroGenero_GeneroId",
                table: "LivroGeneros",
                newName: "IX_LivroGeneros_GeneroId");

            migrationBuilder.AlterColumn<string>(
                name: "LivroImgUrl",
                table: "Livros",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LivroGeneros",
                table: "LivroGeneros",
                columns: new[] { "LivroId", "GeneroId" });

            migrationBuilder.AddForeignKey(
                name: "FK_LivroGeneros_Generos_GeneroId",
                table: "LivroGeneros",
                column: "GeneroId",
                principalTable: "Generos",
                principalColumn: "GeneroId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LivroGeneros_Livros_LivroId",
                table: "LivroGeneros",
                column: "LivroId",
                principalTable: "Livros",
                principalColumn: "LivroId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LivroGeneros_Generos_GeneroId",
                table: "LivroGeneros");

            migrationBuilder.DropForeignKey(
                name: "FK_LivroGeneros_Livros_LivroId",
                table: "LivroGeneros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LivroGeneros",
                table: "LivroGeneros");

            migrationBuilder.RenameTable(
                name: "LivroGeneros",
                newName: "LivroGenero");

            migrationBuilder.RenameIndex(
                name: "IX_LivroGeneros_GeneroId",
                table: "LivroGenero",
                newName: "IX_LivroGenero_GeneroId");

            migrationBuilder.AlterColumn<string>(
                name: "LivroImgUrl",
                table: "Livros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LivroGenero",
                table: "LivroGenero",
                columns: new[] { "LivroId", "GeneroId" });

            migrationBuilder.AddForeignKey(
                name: "FK_LivroGenero_Generos_GeneroId",
                table: "LivroGenero",
                column: "GeneroId",
                principalTable: "Generos",
                principalColumn: "GeneroId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LivroGenero_Livros_LivroId",
                table: "LivroGenero",
                column: "LivroId",
                principalTable: "Livros",
                principalColumn: "LivroId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
