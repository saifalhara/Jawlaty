using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Jawlaty.Migrations
{
    /// <inheritdoc />
    public partial class Cities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transportations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transportations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transportations_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "abd8b0dd-cac6-4003-a54a-b0139bb703fa", "AQAAAAIAAYagAAAAEHuVPKfnT6zZGPiZLdsx7BdgQDmnfxF7i9mgzVW4Ljh860qFLP4uJnEKTP8SUNYBMg==", "10b3e613-aabf-42d5-960a-77c9349a29c4" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Amman" },
                    { 2, "Irbid" },
                    { 3, "Zarqa" },
                    { 4, "Aqaba" },
                    { 5, "Madaba" },
                    { 6, "Jerash" },
                    { 7, "Salt" },
                    { 8, "Mafraq" },
                    { 9, "Karak" },
                    { 10, "Tafilah" },
                    { 11, "Ma'an" },
                    { 12, "Ajloun" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transportations_CityId",
                table: "Transportations",
                column: "CityId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transportations");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "19226664-deda-4d68-8e59-b2d65dc9f79d", "AQAAAAIAAYagAAAAENMXNwnz3tvfpQ2NBjM0R6Co2SPz5WQ18udI9J8qulO4pr5xjnDi96Vjy0EKCKnxvg==", "d6f69846-637c-4a74-bdd6-8834ace3d41c" });
        }
    }
}
