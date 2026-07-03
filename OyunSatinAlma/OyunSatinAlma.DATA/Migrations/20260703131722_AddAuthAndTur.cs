using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OyunSatinAlma.DATA.Migrations
{
    /// <inheritdoc />
    public partial class AddAuthAndTur : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tur",
                table: "Oyunlar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Rol",
                table: "Musteriler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Sifre",
                table: "Musteriler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tur",
                table: "Oyunlar");

            migrationBuilder.DropColumn(
                name: "Rol",
                table: "Musteriler");

            migrationBuilder.DropColumn(
                name: "Sifre",
                table: "Musteriler");
        }
    }
}
