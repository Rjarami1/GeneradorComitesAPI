using Microsoft.EntityFrameworkCore.Migrations;

namespace GeneradorComitesAPI.Migrations
{
    public partial class ComiteeMonths : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComiteeMonths",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComiteeId = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComiteeMonths", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComiteeMonths_Comitees_ComiteeId",
                        column: x => x.ComiteeId,
                        principalTable: "Comitees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComiteeMonths_ComiteeId",
                table: "ComiteeMonths",
                column: "ComiteeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComiteeMonths");
        }
    }
}
