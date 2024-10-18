using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jawlaty.Migrations
{
    /// <inheritdoc />
    public partial class relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Transportations_CityId",
                table: "Transportations");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d43de29a-fa9a-453a-91b2-5972e94cc285", "AQAAAAIAAYagAAAAENPjp1OF920K9MwJiKFqAfXHWodx4FboLV4Hy/4s2o4/8bJAwg1KDCl6TUWr8XXUaw==", "05bbf3ae-32be-4032-b1ac-bc6a908b4130" });

            migrationBuilder.CreateIndex(
                name: "IX_Transportations_CityId",
                table: "Transportations",
                column: "CityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Transportations_CityId",
                table: "Transportations");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "abd8b0dd-cac6-4003-a54a-b0139bb703fa", "AQAAAAIAAYagAAAAEHuVPKfnT6zZGPiZLdsx7BdgQDmnfxF7i9mgzVW4Ljh860qFLP4uJnEKTP8SUNYBMg==", "10b3e613-aabf-42d5-960a-77c9349a29c4" });

            migrationBuilder.CreateIndex(
                name: "IX_Transportations_CityId",
                table: "Transportations",
                column: "CityId",
                unique: true);
        }
    }
}
