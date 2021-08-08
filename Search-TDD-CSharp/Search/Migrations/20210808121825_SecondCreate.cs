using Microsoft.EntityFrameworkCore.Migrations;

namespace Search.Migrations
{
    public partial class SecondCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Datas",
                table: "Datas");

            migrationBuilder.RenameTable(
                name: "Datas",
                newName: "Data");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Data",
                table: "Data",
                column: "Word");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Data",
                table: "Data");

            migrationBuilder.RenameTable(
                name: "Data",
                newName: "Datas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Datas",
                table: "Datas",
                column: "Word");
        }
    }
}
