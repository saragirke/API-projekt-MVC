using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminPoodle.Migrations
{
    /// <inheritdoc />
    public partial class addedmodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommenterName",
                table: "Interest");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Interest",
                type: "TEXT",
                maxLength: 120,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Interest",
                type: "TEXT",
                maxLength: 120,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Buyer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 120, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 120, nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Number = table.Column<int>(type: "INTEGER", nullable: false),
                    PupId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buyer_Pup_PupId",
                        column: x => x.PupId,
                        principalTable: "Pup",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buyer_PupId",
                table: "Buyer",
                column: "PupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buyer");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Interest");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Interest");

            migrationBuilder.AddColumn<string>(
                name: "CommenterName",
                table: "Interest",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
