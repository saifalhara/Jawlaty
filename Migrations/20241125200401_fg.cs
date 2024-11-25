using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jawlaty.Migrations
{
    /// <inheritdoc />
    public partial class fg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "94569453-67af-4fa5-9445-47ab75fe984e", "AQAAAAIAAYagAAAAEIrcOLx0dCwDpt5DVJffzIrqZtSikb/MUKNUrc8bdsdVpg8oLD8Men71zhbO6kuvkA==", "593c8f36-2b91-4161-9c31-e8a72e2a5d14" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "01d5eb85-16de-4f3c-9f16-01c5f774cca3", "AQAAAAIAAYagAAAAELxqLG+fSHfeXMdPlY7vfGeYcfklNpY4pM5W4n9bJN2B8ykhIoM7FzlQiHSCibAKPA==", "56741130-6a75-41e2-8e59-592f4e35749d" });
        }
    }
}
