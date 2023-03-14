using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminPoodle.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate9123 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Puppy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", nullable: false),
                    Booked = table.Column<string>(type: "TEXT", nullable: true),
                    isActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    ImageName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Puppy", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Puppy");
        }
    }
}
