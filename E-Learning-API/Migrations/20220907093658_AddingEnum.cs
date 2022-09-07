using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Learning_API.Migrations
{
    public partial class AddingEnum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "published",
                table: "Courses",
                newName: "Published");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:published", "not_published,published");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Published",
                table: "Courses",
                newName: "published");

            migrationBuilder.AlterDatabase()
                .OldAnnotation("Npgsql:Enum:published", "not_published,published");
        }
    }
}
