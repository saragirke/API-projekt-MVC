using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminPoodle.Migrations
{
    /// <inheritdoc />
    public partial class pup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Puppy");

            migrationBuilder.CreateTable(
                name: "Pup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", nullable: false),
                    Booked = table.Column<bool>(type: "INTEGER", nullable: false),
                    ImageName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pup", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pup");

            migrationBuilder.CreateTable(
                name: "Puppy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Booked = table.Column<bool>(type: "INTEGER", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", nullable: false),
                    ImageName = table.Column<string>(type: "TEXT", nullable: true),
                    Title = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Puppy", x => x.Id);
                });
        }
    }
}
