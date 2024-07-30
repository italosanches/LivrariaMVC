using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LivrariaMVC.Migrations
{
    /// <inheritdoc />
    public partial class addImgUrlAutor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AutorImgUrl",
                table: "Autores",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AutorImgUrl",
                table: "Autores");
        }
    }
}
