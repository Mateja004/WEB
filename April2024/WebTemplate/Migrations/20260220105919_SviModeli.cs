using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebTemplate.Migrations
{
    /// <inheritdoc />
    public partial class SviModeli : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sala",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojSedista = table.Column<int>(type: "int", nullable: false),
                    BrojRedova = table.Column<int>(type: "int", nullable: false),
                    NazivSale = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sala", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Projekcija",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivProjekcije = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VremePikaza = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SalaID = table.Column<int>(type: "int", nullable: true),
                    sifra = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projekcija", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Projekcija_Sala_SalaID",
                        column: x => x.SalaID,
                        principalTable: "Sala",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Karta",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CenaKarte = table.Column<int>(type: "int", nullable: false),
                    ProjekcijaID = table.Column<int>(type: "int", nullable: true),
                    RedNaKarti = table.Column<int>(type: "int", nullable: false),
                    SedisteNaKarti = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Karta", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Karta_Projekcija_ProjekcijaID",
                        column: x => x.ProjekcijaID,
                        principalTable: "Projekcija",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Karta_ProjekcijaID",
                table: "Karta",
                column: "ProjekcijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Projekcija_SalaID",
                table: "Projekcija",
                column: "SalaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Karta");

            migrationBuilder.DropTable(
                name: "Projekcija");

            migrationBuilder.DropTable(
                name: "Sala");
        }
    }
}
