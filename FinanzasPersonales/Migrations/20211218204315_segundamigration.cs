using Microsoft.EntityFrameworkCore.Migrations;

namespace FinanzasPersonales.Migrations
{
    public partial class segundamigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FechaIngreso",
                table: "Gasto",
                newName: "FechaGasto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FechaGasto",
                table: "Gasto",
                newName: "FechaIngreso");
        }
    }
}
