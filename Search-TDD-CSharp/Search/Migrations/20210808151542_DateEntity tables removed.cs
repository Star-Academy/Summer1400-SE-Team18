using Microsoft.EntityFrameworkCore.Migrations;

namespace Search.Migrations
{
    public partial class DateEntitytablesremoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Data");

            migrationBuilder.CreateTable(
                name: "DataEntities",
                columns: table => new
                {
                    Word = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataEntities", x => new { x.Word, x.FileName });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataEntities");

            migrationBuilder.CreateTable(
                name: "Data",
                columns: table => new
                {
                    Word = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Data", x => x.Word);
                });
        }
    }
}
