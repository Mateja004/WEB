using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebTemplate.Migrations
{
    /// <inheritdoc />
    public partial class Svi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "imeiprezime",
                table: "Korisniks",
                newName: "prezime");

            migrationBuilder.AddColumn<string>(
                name: "ime",
                table: "Korisniks",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ime",
                table: "Korisniks");

            migrationBuilder.RenameColumn(
                name: "prezime",
                table: "Korisniks",
                newName: "imeiprezime");
        }
    }
}
