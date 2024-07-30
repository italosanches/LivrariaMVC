using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LivrariaMVC.Migrations
{
    /// <inheritdoc />
    public partial class adicionaimg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LivroImgUrl",
                table: "Livros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LivroImgUrl",
                table: "Livros");
        }
    }
}
