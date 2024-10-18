using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jawlaty.Migrations
{
    /// <inheritdoc />
    public partial class cityIdfix2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a15c2006-0103-4895-9496-d272bce06ed3", "AQAAAAIAAYagAAAAEPkGq2FCkf/4yAvLBlwRWYqX8h8VMXZubZ5UfmOUh8jybQ4FVRbyp9gnCrAwiiBn7w==", "a86d6794-9637-455a-9179-b3cc08b38014" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0b2aea7b-d28a-497e-83a6-9347f6b48540", "AQAAAAIAAYagAAAAEIJslOqgxlLNXDA6p8rsptyZvfDWWLlVMv2G05cYTui4wawAS7jL97i86Fg3lhF/kw==", "083baa5f-425b-4067-a55e-ce82c2588481" });
        }
    }
}
