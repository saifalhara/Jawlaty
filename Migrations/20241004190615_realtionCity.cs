using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jawlaty.Migrations
{
    /// <inheritdoc />
    public partial class realtionCity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Place_Cities_CityId",
                table: "Place");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavorites_Place_EntertainmentId",
                table: "UserFavorites");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavorites_Place_HotelId",
                table: "UserFavorites");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavorites_Place_RestaurantId",
                table: "UserFavorites");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRatings_Place_EntertainmentId",
                table: "UserRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRatings_Place_HotelId",
                table: "UserRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRatings_Place_RestaurantId",
                table: "UserRatings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Place",
                table: "Place");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Place");

            migrationBuilder.DropColumn(
                name: "Entertainment_AverageRating",
                table: "Place");

            migrationBuilder.DropColumn(
                name: "Restaurant_AverageRating",
                table: "Place");

            migrationBuilder.RenameTable(
                name: "Place",
                newName: "Restaurants");

            migrationBuilder.RenameIndex(
                name: "IX_Place_CityId",
                table: "Restaurants",
                newName: "IX_Restaurants_CityId");

            migrationBuilder.AlterColumn<double>(
                name: "AverageRating",
                table: "Restaurants",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Restaurants",
                table: "Restaurants",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Entertainments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AverageRating = table.Column<double>(type: "float", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entertainments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entertainments_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AverageRating = table.Column<double>(type: "float", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hotels_Cities_CityId",
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
                values: new object[] { "09286305-835c-4d3d-9d53-18146ae6347b", "AQAAAAIAAYagAAAAEAvjIHLckjeEq/ghiA0dSIrllF08nBckRKJhFnHmRRHWb+xqYNqaaRZ0EWGMV0DvOQ==", "0f1fce24-9c2e-41d4-8a76-ec8f701fb1c2" });

            migrationBuilder.CreateIndex(
                name: "IX_Entertainments_CityId",
                table: "Entertainments",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_CityId",
                table: "Hotels",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Cities_CityId",
                table: "Restaurants",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavorites_Entertainments_EntertainmentId",
                table: "UserFavorites",
                column: "EntertainmentId",
                principalTable: "Entertainments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavorites_Hotels_HotelId",
                table: "UserFavorites",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavorites_Restaurants_RestaurantId",
                table: "UserFavorites",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRatings_Entertainments_EntertainmentId",
                table: "UserRatings",
                column: "EntertainmentId",
                principalTable: "Entertainments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRatings_Hotels_HotelId",
                table: "UserRatings",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRatings_Restaurants_RestaurantId",
                table: "UserRatings",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Cities_CityId",
                table: "Restaurants");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavorites_Entertainments_EntertainmentId",
                table: "UserFavorites");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavorites_Hotels_HotelId",
                table: "UserFavorites");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavorites_Restaurants_RestaurantId",
                table: "UserFavorites");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRatings_Entertainments_EntertainmentId",
                table: "UserRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRatings_Hotels_HotelId",
                table: "UserRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRatings_Restaurants_RestaurantId",
                table: "UserRatings");

            migrationBuilder.DropTable(
                name: "Entertainments");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Restaurants",
                table: "Restaurants");

            migrationBuilder.RenameTable(
                name: "Restaurants",
                newName: "Place");

            migrationBuilder.RenameIndex(
                name: "IX_Restaurants_CityId",
                table: "Place",
                newName: "IX_Place_CityId");

            migrationBuilder.AlterColumn<double>(
                name: "AverageRating",
                table: "Place",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Place",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Entertainment_AverageRating",
                table: "Place",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Restaurant_AverageRating",
                table: "Place",
                type: "float",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Place",
                table: "Place",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a15c2006-0103-4895-9496-d272bce06ed3", "AQAAAAIAAYagAAAAEPkGq2FCkf/4yAvLBlwRWYqX8h8VMXZubZ5UfmOUh8jybQ4FVRbyp9gnCrAwiiBn7w==", "a86d6794-9637-455a-9179-b3cc08b38014" });

            migrationBuilder.AddForeignKey(
                name: "FK_Place_Cities_CityId",
                table: "Place",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavorites_Place_EntertainmentId",
                table: "UserFavorites",
                column: "EntertainmentId",
                principalTable: "Place",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavorites_Place_HotelId",
                table: "UserFavorites",
                column: "HotelId",
                principalTable: "Place",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavorites_Place_RestaurantId",
                table: "UserFavorites",
                column: "RestaurantId",
                principalTable: "Place",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRatings_Place_EntertainmentId",
                table: "UserRatings",
                column: "EntertainmentId",
                principalTable: "Place",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRatings_Place_HotelId",
                table: "UserRatings",
                column: "HotelId",
                principalTable: "Place",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRatings_Place_RestaurantId",
                table: "UserRatings",
                column: "RestaurantId",
                principalTable: "Place",
                principalColumn: "Id");
        }
    }
}
