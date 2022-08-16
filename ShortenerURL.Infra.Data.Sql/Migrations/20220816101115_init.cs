using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShortenerURL.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UrlEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrlId = table.Column<int>(type: "int", nullable: false),
                    UrlKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LongUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrlEntities", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UrlEntities_UrlId",
                table: "UrlEntities",
                column: "UrlId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UrlEntities_UrlKey",
                table: "UrlEntities",
                column: "UrlKey",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UrlEntities");
        }
    }
}
