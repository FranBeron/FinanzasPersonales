using Microsoft.EntityFrameworkCore.Migrations;

namespace FinanzasPersonales.Migrations
{
    public partial class terceramigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Ingreso");

            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Gasto");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Ingreso",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Gasto",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "categoriaGastos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoriaGastos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "categoriaIngresos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoriaIngresos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingreso_CategoriaId",
                table: "Ingreso",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Gasto_CategoriaId",
                table: "Gasto",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gasto_categoriaGastos_CategoriaId",
                table: "Gasto",
                column: "CategoriaId",
                principalTable: "categoriaGastos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingreso_categoriaIngresos_CategoriaId",
                table: "Ingreso",
                column: "CategoriaId",
                principalTable: "categoriaIngresos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gasto_categoriaGastos_CategoriaId",
                table: "Gasto");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingreso_categoriaIngresos_CategoriaId",
                table: "Ingreso");

            migrationBuilder.DropTable(
                name: "categoriaGastos");

            migrationBuilder.DropTable(
                name: "categoriaIngresos");

            migrationBuilder.DropIndex(
                name: "IX_Ingreso_CategoriaId",
                table: "Ingreso");

            migrationBuilder.DropIndex(
                name: "IX_Gasto_CategoriaId",
                table: "Gasto");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Ingreso");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Gasto");

            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "Ingreso",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "Gasto",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
