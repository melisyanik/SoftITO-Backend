using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiletSinema.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategori",
                columns: table => new
                {
                    KategoriNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriAdi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategori", x => x.KategoriNo);
                });

            migrationBuilder.CreateTable(
                name: "Diziler",
                columns: table => new
                {
                    DiziNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BolumSayisi = table.Column<int>(type: "int", nullable: false),
                    Yorum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Puan = table.Column<double>(type: "float", nullable: false),
                    KategoriNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diziler", x => x.DiziNo);
                    table.ForeignKey(
                        name: "FK_Diziler_Kategori_KategoriNo",
                        column: x => x.KategoriNo,
                        principalTable: "Kategori",
                        principalColumn: "KategoriNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Filmler",
                columns: table => new
                {
                    FilmNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BolumSayisi = table.Column<int>(type: "int", nullable: false),
                    Yorum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Puan = table.Column<double>(type: "float", nullable: false),
                    KategoriNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmler", x => x.FilmNo);
                    table.ForeignKey(
                        name: "FK_Filmler_Kategori_KategoriNo",
                        column: x => x.KategoriNo,
                        principalTable: "Kategori",
                        principalColumn: "KategoriNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tiyatrolar",
                columns: table => new
                {
                    TiyatroNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BolumSayisi = table.Column<int>(type: "int", nullable: false),
                    Yorum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Puan = table.Column<double>(type: "float", nullable: false),
                    KategoriNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tiyatrolar", x => x.TiyatroNo);
                    table.ForeignKey(
                        name: "FK_Tiyatrolar_Kategori_KategoriNo",
                        column: x => x.KategoriNo,
                        principalTable: "Kategori",
                        principalColumn: "KategoriNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diziler_KategoriNo",
                table: "Diziler",
                column: "KategoriNo");

            migrationBuilder.CreateIndex(
                name: "IX_Filmler_KategoriNo",
                table: "Filmler",
                column: "KategoriNo");

            migrationBuilder.CreateIndex(
                name: "IX_Tiyatrolar_KategoriNo",
                table: "Tiyatrolar",
                column: "KategoriNo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diziler");

            migrationBuilder.DropTable(
                name: "Filmler");

            migrationBuilder.DropTable(
                name: "Tiyatrolar");

            migrationBuilder.DropTable(
                name: "Kategori");
        }
    }
}
