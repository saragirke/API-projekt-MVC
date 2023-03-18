using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminPoodle.Migrations
{
    /// <inheritdoc />
    public partial class alttextpup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AltText",
                table: "Pup",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AltText",
                table: "Pup");
        }
    }
}
