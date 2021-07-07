using Microsoft.EntityFrameworkCore.Migrations;

namespace GeneradorComitesAPI.Migrations
{
    public partial class PersonsComitees : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonsComitees",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    ComiteeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonsComitees", x => new { x.PersonId, x.ComiteeId });
                    table.ForeignKey(
                        name: "FK_PersonsComitees_Comitees_ComiteeId",
                        column: x => x.ComiteeId,
                        principalTable: "Comitees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonsComitees_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonsComitees_ComiteeId",
                table: "PersonsComitees",
                column: "ComiteeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonsComitees");
        }
    }
}
