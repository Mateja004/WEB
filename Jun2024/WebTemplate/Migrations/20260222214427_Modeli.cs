using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebTemplate.Migrations
{
    /// <inheritdoc />
    public partial class Modeli : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Korisniks",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    imeiprezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JMBG = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    brojDozvole = table.Column<int>(type: "int", maxLength: 9, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisniks", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Vozilos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PredjenaKilometraza = table.Column<int>(type: "int", nullable: false),
                    godiste = table.Column<int>(type: "int", nullable: false),
                    brojSedista = table.Column<int>(type: "int", nullable: false),
                    cenapodanu = table.Column<int>(type: "int", nullable: false),
                    iznajmljen = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vozilos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Iznajmljivanjes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    brojDana = table.Column<int>(type: "int", nullable: false),
                    KorisnikID = table.Column<int>(type: "int", nullable: true),
                    VoziloID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Iznajmljivanjes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Iznajmljivanjes_Korisniks_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "Korisniks",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Iznajmljivanjes_Vozilos_VoziloID",
                        column: x => x.VoziloID,
                        principalTable: "Vozilos",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Iznajmljivanjes_KorisnikID",
                table: "Iznajmljivanjes",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Iznajmljivanjes_VoziloID",
                table: "Iznajmljivanjes",
                column: "VoziloID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Iznajmljivanjes");

            migrationBuilder.DropTable(
                name: "Korisniks");

            migrationBuilder.DropTable(
                name: "Vozilos");
        }
    }
}
