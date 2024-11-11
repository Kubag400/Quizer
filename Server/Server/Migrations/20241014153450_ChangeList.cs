using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class ChangeList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Answer2",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Answer3",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Answer4",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "Answer1",
                table: "Questions",
                newName: "Answers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Answers",
                table: "Questions",
                newName: "Answer1");

            migrationBuilder.AddColumn<string>(
                name: "Answer2",
                table: "Questions",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Answer3",
                table: "Questions",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Answer4",
                table: "Questions",
                type: "TEXT",
                nullable: true);
        }
    }
}
