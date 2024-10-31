using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jawlaty.Migrations
{
    /// <inheritdoc />
    public partial class edit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Venue",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "VenueType",
                table: "Venue",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "19083016-707d-430a-8c51-701a6db8d896", "AQAAAAIAAYagAAAAELCvxqsSRjfcpuiGgBDqbOQ+R/CHtUY/mZRgl2C361Rt6uP+0AajgpZkDaRkb3AOMQ==", "a96750ef-cf9e-4504-b6be-7dc0bac89e6c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Venue");

            migrationBuilder.DropColumn(
                name: "VenueType",
                table: "Venue");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "50923f83-e746-46c9-8cf4-99e23781f9c6", "AQAAAAIAAYagAAAAEDWyDsQJmxPY6CcprdJ3Jt9yvHVv28/aoOkG7FCnsddQtEYUGxKvAslx9wTHa1k1dQ==", "b59d3968-fb51-4658-a193-2d4b00a6dd24" });
        }
    }
}
