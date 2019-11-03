using Microsoft.EntityFrameworkCore.Migrations;

namespace MyScriptureJournal.Migrations
{
    public partial class AddChapter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Chapter",
                table: "Scripture",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Chapter",
                table: "Scripture");
        }
    }
}
