using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiletSinema.Migrations
{
    /// <inheritdoc />
    public partial class RemoveBolumSayisiFromFilmler : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BolumSayisi",
                table: "Filmler");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BolumSayisi",
                table: "Filmler",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
