using Microsoft.EntityFrameworkCore.Migrations;

namespace PremiumCalculator.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Occupations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occupations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Factor = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OccupationRatings",
                columns: table => new
                {
                    OccupationId = table.Column<int>(type: "int", nullable: false),
                    RatingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OccupationRatings", x => new { x.OccupationId, x.RatingId });
                    table.ForeignKey(
                        name: "FK_OccupationRatings_Occupations_OccupationId",
                        column: x => x.OccupationId,
                        principalTable: "Occupations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OccupationRatings_Ratings_RatingId",
                        column: x => x.RatingId,
                        principalTable: "Ratings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Occupations",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 10001, "Cleaner" },
                    { 10002, "Doctor" },
                    { 10003, "Author" },
                    { 10004, "Farmer" },
                    { 10005, "Mechanic" },
                    { 10006, "Florist" }
                });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "Factor", "Name" },
                values: new object[,]
                {
                    { 20001, 1.0, "Professional" },
                    { 20002, 1.25, "White Collar" },
                    { 20003, 1.5, "Light Manual" },
                    { 20004, 1.75, "Heavy Manual" }
                });

            migrationBuilder.InsertData(
                table: "OccupationRatings",
                columns: new[] { "OccupationId", "RatingId" },
                values: new object[,]
                {
                    { 10002, 20001 },
                    { 10003, 20002 },
                    { 10001, 20003 },
                    { 10006, 20003 },
                    { 10004, 20004 },
                    { 10005, 20004 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OccupationRatings_OccupationId",
                table: "OccupationRatings",
                column: "OccupationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OccupationRatings_RatingId",
                table: "OccupationRatings",
                column: "RatingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OccupationRatings");

            migrationBuilder.DropTable(
                name: "Occupations");

            migrationBuilder.DropTable(
                name: "Ratings");
        }
    }
}
