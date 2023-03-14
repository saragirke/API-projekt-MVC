using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminPoodle.Migrations
{
    /// <inheritdoc />
    public partial class Puppy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Puppy");

            migrationBuilder.AlterColumn<bool>(
                name: "Booked",
                table: "Puppy",
                type: "INTEGER",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Booked",
                table: "Puppy",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Puppy",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }
    }
}
