using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Learning_API.Migrations
{
    public partial class UpdateCoursesModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "published",
                table: "Courses",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "published",
                table: "Courses");
        }
    }
}
