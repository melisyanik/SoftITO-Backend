using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiletSinema.Migrations
{
    /// <inheritdoc />
    public partial class TiyatroUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BolumSayisi",
                table: "Tiyatrolar",
                newName: "Sure");

            migrationBuilder.AddColumn<string>(
                name: "YazarAdi",
                table: "Tiyatrolar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YazarAdi",
                table: "Tiyatrolar");

            migrationBuilder.RenameColumn(
                name: "Sure",
                table: "Tiyatrolar",
                newName: "BolumSayisi");
        }
    }
}
