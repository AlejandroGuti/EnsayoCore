using Microsoft.EntityFrameworkCore.Migrations;

namespace Alone.Migrations
{
    public partial class AgragadoMuchos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Babosa",
                table: "Babosa");

            migrationBuilder.RenameTable(
                name: "Babosa",
                newName: "CosaAs");

            migrationBuilder.AddColumn<int>(
                name: "Total",
                table: "CosaAs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CosaAs",
                table: "CosaAs",
                column: "id");

            migrationBuilder.CreateTable(
                name: "CosaBs",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameB = table.Column<string>(nullable: true),
                    TotalB = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CosaBs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CosaACosaBs",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CosaId = table.Column<int>(nullable: false),
                    CosaBId = table.Column<int>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CosaACosaBs", x => x.id);
                    table.ForeignKey(
                        name: "FK_CosaACosaBs_CosaBs_CosaBId",
                        column: x => x.CosaBId,
                        principalTable: "CosaBs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CosaACosaBs_CosaAs_CosaId",
                        column: x => x.CosaId,
                        principalTable: "CosaAs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CosaACosaBs_CosaBId",
                table: "CosaACosaBs",
                column: "CosaBId");

            migrationBuilder.CreateIndex(
                name: "IX_CosaACosaBs_CosaId",
                table: "CosaACosaBs",
                column: "CosaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CosaACosaBs");

            migrationBuilder.DropTable(
                name: "CosaBs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CosaAs",
                table: "CosaAs");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "CosaAs");

            migrationBuilder.RenameTable(
                name: "CosaAs",
                newName: "Babosa");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Babosa",
                table: "Babosa",
                column: "id");
        }
    }
}
