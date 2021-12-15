using Microsoft.EntityFrameworkCore.Migrations;

namespace movies.data.Migrations
{
    public partial class SearchTypeColumnAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SearchType",
                table: "UserSearchLogs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SearchType",
                table: "UserSearchLogs");
        }
    }
}
