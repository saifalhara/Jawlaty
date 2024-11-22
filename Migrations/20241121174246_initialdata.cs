using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jawlaty.Migrations
{
    /// <inheritdoc />
    public partial class initialdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Art",
                table: "Hotels",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Food",
                table: "Hotels",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "History",
                table: "Hotels",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Shopping",
                table: "Hotels",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Sports",
                table: "Hotels",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a2b896dd-c8bb-4dea-922d-641306b3796e", "AQAAAAIAAYagAAAAEKTDFmo205Cj0buEbRYCLmHn3/7wctVVOfaiywleStloI5NwJxkDxCdZivaii5fVeQ==", "d004e5f1-2ff3-49a6-9849-7ab8f6b8c8a2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Art",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "Food",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "History",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "Shopping",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "Sports",
                table: "Hotels");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0fd07073-93c7-42ce-bfda-517946875cff", "AQAAAAIAAYagAAAAEF3/9pJspULvDbueG7Qsexz6L0rPuINStYLXfepkgsrd+QvqsNofdh6+qhMqixmO8w==", "294fb466-360e-4c40-85c1-83d8b260a778" });
        }
    }
}
