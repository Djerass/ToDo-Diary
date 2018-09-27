using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoDiaryWeb.Migrations
{
    public partial class UpdateExercise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Technique",
                table: "Exercises",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Exercises",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Technique",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Exercises");
        }
    }
}
