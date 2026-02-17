using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebTemplate.Migrations
{
    /// <inheritdoc />
    public partial class Rezervoari : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rezervoars",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sifra = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Zapremina = table.Column<int>(type: "int", nullable: false),
                    temperatura = table.Column<int>(type: "int", nullable: false),
                    PoslednjeCiscenje = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FrekvencijaCiscenja = table.Column<int>(type: "int", nullable: false),
                    Kapacitet = table.Column<int>(type: "int", nullable: false),
                    BrojRiba = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervoars", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rezervoars");
        }
    }
}
