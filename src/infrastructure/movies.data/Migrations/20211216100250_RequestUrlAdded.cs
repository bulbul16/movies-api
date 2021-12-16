using Microsoft.EntityFrameworkCore.Migrations;

namespace movies.data.Migrations
{
    public partial class RequestUrlAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RequestUrl",
                table: "UserSearchLogs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequestUrl",
                table: "UserSearchLogs");
        }
    }
}
