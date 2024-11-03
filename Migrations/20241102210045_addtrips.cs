using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jawlaty.Migrations
{
    /// <inheritdoc />
    public partial class addtrips : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfDay = table.Column<byte>(type: "tinyint", nullable: false),
                    Withtraveling = table.Column<int>(type: "int", nullable: false),
                    Interest = table.Column<int>(type: "int", nullable: false),
                    HasChlidren = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.ID);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6ede2c54-a1c3-4c19-ad7e-cc2aba9a6857", "AQAAAAIAAYagAAAAEDOE17tOQ64Z3PF9ebyF3xH8I1psgg0qhL3sPmfTykZvOJIfqZzJ6cby9PysuzdqIw==", "2622de32-977b-44f1-a3b0-532cd5766293" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9196633b-f715-45ef-8eae-25cfae88e0f2", "AQAAAAIAAYagAAAAEJUAU4+E4I1ny0AqC/4fJPdCXLwFuqxITZyOn51a8E0tqqjlD1iux4KiI/LqN0D1KQ==", "ae31c42f-479a-4fe5-9332-848acdc6537f" });
        }
    }
}
