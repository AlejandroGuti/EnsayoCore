using Microsoft.EntityFrameworkCore.Migrations;

namespace Mod5Core.Migrations
{
    public partial class UpdateAll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Titulo",
                table: "Libros");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Autores");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Libros",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BornDate",
                table: "Autores",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Identification",
                table: "Autores",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Autores",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Libros");

            migrationBuilder.DropColumn(
                name: "BornDate",
                table: "Autores");

            migrationBuilder.DropColumn(
                name: "Identification",
                table: "Autores");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Autores");

            migrationBuilder.AddColumn<string>(
                name: "Titulo",
                table: "Libros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Autores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
