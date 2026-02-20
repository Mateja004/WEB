using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebTemplate.Migrations
{
    /// <inheritdoc />
    public partial class Chat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chat",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    A_KorisnikID = table.Column<int>(type: "int", nullable: true),
                    A_ChatSobaID = table.Column<int>(type: "int", nullable: true),
                    Nadimak = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Boja = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chat", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Chat_ChatSoba_A_ChatSobaID",
                        column: x => x.A_ChatSobaID,
                        principalTable: "ChatSoba",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Chat_Korisnik_A_KorisnikID",
                        column: x => x.A_KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chat_A_ChatSobaID",
                table: "Chat",
                column: "A_ChatSobaID");

            migrationBuilder.CreateIndex(
                name: "IX_Chat_A_KorisnikID",
                table: "Chat",
                column: "A_KorisnikID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chat");
        }
    }
}
