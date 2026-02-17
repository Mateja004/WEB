using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebTemplate.Migrations
{
    /// <inheritdoc />
    public partial class Akvarijumi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Akvarijums",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumDodavanja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    brojjediniki = table.Column<int>(type: "int", nullable: false),
                    P_RezervoarID = table.Column<int>(type: "int", nullable: true),
                    P_RibaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Akvarijums", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Akvarijums_Rezervoars_P_RezervoarID",
                        column: x => x.P_RezervoarID,
                        principalTable: "Rezervoars",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Akvarijums_Ribas_P_RibaID",
                        column: x => x.P_RibaID,
                        principalTable: "Ribas",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Akvarijums_P_RezervoarID",
                table: "Akvarijums",
                column: "P_RezervoarID");

            migrationBuilder.CreateIndex(
                name: "IX_Akvarijums_P_RibaID",
                table: "Akvarijums",
                column: "P_RibaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Akvarijums");
        }
    }
}
