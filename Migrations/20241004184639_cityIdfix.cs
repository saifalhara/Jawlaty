using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jawlaty.Migrations
{
    /// <inheritdoc />
    public partial class cityIdfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<double>(
                name: "AverageRating",
                table: "Place",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Place",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                values: new object[] { "0b2aea7b-d28a-497e-83a6-9347f6b48540", "AQAAAAIAAYagAAAAEIJslOqgxlLNXDA6p8rsptyZvfDWWLlVMv2G05cYTui4wawAS7jL97i86Fg3lhF/kw==", "083baa5f-425b-4067-a55e-ce82c2588481" });

            migrationBuilder.CreateIndex(
                name: "IX_Place_CityId",
                table: "Place",
                column: "CityId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_Place_CityId",
                table: "Place");

            migrationBuilder.DropColumn(
                name: "CityId",
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
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entertainments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AverageRating = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d43de29a-fa9a-453a-91b2-5972e94cc285", "AQAAAAIAAYagAAAAENPjp1OF920K9MwJiKFqAfXHWodx4FboLV4Hy/4s2o4/8bJAwg1KDCl6TUWr8XXUaw==", "05bbf3ae-32be-4032-b1ac-bc6a908b4130" });

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
    }
}
