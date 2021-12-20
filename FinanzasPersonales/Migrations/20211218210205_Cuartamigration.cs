using Microsoft.EntityFrameworkCore.Migrations;

namespace FinanzasPersonales.Migrations
{
    public partial class Cuartamigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gasto_categoriaGastos_CategoriaId",
                table: "Gasto");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingreso_categoriaIngresos_CategoriaId",
                table: "Ingreso");

            migrationBuilder.DropPrimaryKey(
                name: "PK_categoriaIngresos",
                table: "categoriaIngresos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_categoriaGastos",
                table: "categoriaGastos");

            migrationBuilder.RenameTable(
                name: "categoriaIngresos",
                newName: "CategoriaIngresos");

            migrationBuilder.RenameTable(
                name: "categoriaGastos",
                newName: "CategoriaGastos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoriaIngresos",
                table: "CategoriaIngresos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoriaGastos",
                table: "CategoriaGastos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Gasto_CategoriaGastos_CategoriaId",
                table: "Gasto",
                column: "CategoriaId",
                principalTable: "CategoriaGastos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingreso_CategoriaIngresos_CategoriaId",
                table: "Ingreso",
                column: "CategoriaId",
                principalTable: "CategoriaIngresos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gasto_CategoriaGastos_CategoriaId",
                table: "Gasto");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingreso_CategoriaIngresos_CategoriaId",
                table: "Ingreso");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoriaIngresos",
                table: "CategoriaIngresos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoriaGastos",
                table: "CategoriaGastos");

            migrationBuilder.RenameTable(
                name: "CategoriaIngresos",
                newName: "categoriaIngresos");

            migrationBuilder.RenameTable(
                name: "CategoriaGastos",
                newName: "categoriaGastos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_categoriaIngresos",
                table: "categoriaIngresos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_categoriaGastos",
                table: "categoriaGastos",
                column: "Id");

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
    }
}
