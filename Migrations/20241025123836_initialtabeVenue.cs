using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jawlaty.Migrations
{
    /// <inheritdoc />
    public partial class initialtabeVenue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Venue",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EnName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CityID = table.Column<int>(type: "int", nullable: false),
                    Succsed = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venue", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Venue_Cities_CityID",
                        column: x => x.CityID,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "50923f83-e746-46c9-8cf4-99e23781f9c6", "AQAAAAIAAYagAAAAEDWyDsQJmxPY6CcprdJ3Jt9yvHVv28/aoOkG7FCnsddQtEYUGxKvAslx9wTHa1k1dQ==", "b59d3968-fb51-4658-a193-2d4b00a6dd24" });

            migrationBuilder.CreateIndex(
                name: "IX_Venue_CityID",
                table: "Venue",
                column: "CityID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Venue");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d7b6f19d-c33c-4c8c-b865-5f2f9cc80da8", "AQAAAAIAAYagAAAAEG40fyk/iZ+lLWIGUvFWcwS3L0e72JgDkrcfTKaShDvQP6rcIGH60iKB3U36cFdEow==", "823235e7-aa32-4059-ba75-ae24650f6c66" });
        }
    }
}
