using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jawlaty.Migrations
{
    /// <inheritdoc />
    public partial class addQuestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.ID);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9196633b-f715-45ef-8eae-25cfae88e0f2", "AQAAAAIAAYagAAAAEJUAU4+E4I1ny0AqC/4fJPdCXLwFuqxITZyOn51a8E0tqqjlD1iux4KiI/LqN0D1KQ==", "ae31c42f-479a-4fe5-9332-848acdc6537f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "19083016-707d-430a-8c51-701a6db8d896", "AQAAAAIAAYagAAAAELCvxqsSRjfcpuiGgBDqbOQ+R/CHtUY/mZRgl2C361Rt6uP+0AajgpZkDaRkb3AOMQ==", "a96750ef-cf9e-4504-b6be-7dc0bac89e6c" });
        }
    }
}
