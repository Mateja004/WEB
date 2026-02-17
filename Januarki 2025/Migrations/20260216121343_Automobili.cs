using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebTemplate.Migrations
{
    /// <inheritdoc />
    public partial class Automobili : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Automobil",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    kilometraza = table.Column<int>(type: "int", nullable: false),
                    godiste = table.Column<DateTime>(type: "datetime2", nullable: false),
                    brojsedista = table.Column<int>(type: "int", nullable: false),
                    cenapodanu = table.Column<int>(type: "int", nullable: false),
                    Iznajmljen = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Automobil", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Automobil");
        }
    }
}
