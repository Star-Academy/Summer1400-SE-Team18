using Microsoft.EntityFrameworkCore.Migrations;

namespace Search.Migrations
{
    public partial class FileandDataAndFiletablesadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataAndFiles",
                columns: table => new
                {
                    DataKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FileKey = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataAndFiles", x => new { x.DataKey, x.FileKey });
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    HashCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.HashCode);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataAndFiles");

            migrationBuilder.DropTable(
                name: "Files");
        }
    }
}
